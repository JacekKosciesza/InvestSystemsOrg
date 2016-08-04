using System.Linq;
using AutoMapper;
using InvSys.Companies.Api.Model;
using InvSys.Companies.Core.Services;
using InvSys.Companies.Core.State;
using InvSys.Companies.State.EntityFramework;
using InvSys.Companies.State.EntityFramework.Repositories;
using InvSys.Companies.State.EntityFramework.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Swashbuckle.Swagger.Model;

namespace InvSys.Companies.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            _mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Company, Core.Model.Company>()
                    .ForMember(d => d.Translations, opt => opt.MapFrom(s => 
                        new List<Core.Model.CompanyTranslation> { new Core.Model.CompanyTranslation { Culture = s.Culture ?? "en-US", Description = s.Description }
                    }));
                config.CreateMap<Core.Model.Company, Company>()
                    .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == "en-US").Description)) // TODO: make 'en-US' a parameter
                    .ForMember(d => d.Culture, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == "en-US").Culture)); // TODO: make 'en-US' a parameter
                config.AllowNullCollections = true;
            });
        }

        public IConfigurationRoot Configuration { get; }
        private MapperConfiguration _mapperConfiguration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(Configuration);
            services.AddMvc();

            // Swagger
            services.AddSwaggerGen(c =>
                 c.SingleApiVersion(new Info
                 {
                     Version = "v1",
                     Title = "Companies API",
                     Description = "Companies API for InvestSystems.org",
                     TermsOfService = "Use at your own risk",
                 })
            );
            //if (_hostingEnv.IsDevelopment())
            //{
            //    services.ConfigureSwaggerGen(c =>
            //    {
            //        c.IncludeXmlComments(GetXmlCommentsPath());
            //    });
            //}

            services.AddDbContext<CompaniesContext>();
            services.AddTransient<CompaniesContextSeedData>();
            services.AddScoped<ICompaniesService, CompaniesService>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CompaniesContextSeedData seeder)
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();

            // Swagger
            app.UseSwagger((httpRequest, swaggerDoc) =>
            {
                swaggerDoc.Host = httpRequest.Host.Value;
            });
            app.UseSwaggerUi();

            seeder.EnsureSeedData().Wait();
        }
    }
}
