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
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using InvSys.Shared.Api.Authorization;
using Microsoft.AspNetCore.Authorization;

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
                        new List<Core.Model.CompanyTranslation> { new Core.Model.CompanyTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Description = s.Description }
                    }));
                config.CreateMap<Core.Model.Company, Company>()
                    .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Description)) // TODO: make 'en-US' a parameter
                    .ForMember(d => d.Culture, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Culture)); // TODO: make 'en-US' a parameter
                config.AllowNullCollections = true;
            });
        }

        public IConfigurationRoot Configuration { get; }
        private MapperConfiguration _mapperConfiguration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddSingleton(Configuration);
            services.AddMvc()
                .AddDataAnnotationsLocalization();

            // Swagger
            services.AddSwaggerGen(c =>
                 c.SingleApiVersion(new Info
                 {
                     Version = Configuration["Swagger:Version"],
                     Title = Configuration["Swagger:Title"],
                     Description = Configuration["Swagger:Description"],
                     TermsOfService = Configuration["Swagger:TermsOfService"]
                 })
            );
            //if (_hostingEnv.IsDevelopment())
            //{
            //    services.ConfigureSwaggerGen(c =>
            //    {
            //        c.IncludeXmlComments(GetXmlCommentsPath());
            //    });
            //}

            // Custom policy-based authorization
            services.AddAuthorization(options =>
                options.AddPolicy("Admin", policy => policy.Requirements.Add(new RoleRequirement("Admin")))
            );
            services.AddSingleton<IAuthorizationHandler, RoleHandler>();

            services.AddDbContext<CompaniesContext>();
            services.AddTransient<CompaniesContextSeedData>();
            services.AddScoped<ICompaniesService, CompaniesService>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CompaniesContextSeedData seeder)
        {

            var supportedCultures = Configuration["Globalization:SupportedCultures"].Split(';').Select(c => new CultureInfo(c.Trim())).ToList();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(Configuration["Globalization:DefaultCulture"]),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseOAuthIntrospection(options => {
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.Authority = Configuration["Authorization:OAuth:Introspection:Authority"];
                options.ClientId = Configuration["Authorization:OAuth:Introspection:ClientId"];
                options.ClientSecret = Configuration["Authorization:OAuth:Introspection:ClientSecret"];
            });
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
