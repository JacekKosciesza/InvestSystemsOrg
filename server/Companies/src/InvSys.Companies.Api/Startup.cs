using System.Linq;
using AutoMapper;
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
using System.Globalization;
using InvSys.Companies.Core.Models;
using Company = InvSys.Companies.Api.Models.Company;
using InvSys.Shared.Api.Startup;

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
                config.CreateMap<Company, Core.Models.Company>()
                    .ForMember(d => d.Translations, opt => opt.MapFrom(s => 
                        new List<CompanyTranslation> { new CompanyTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Description = s.Description }
                    }));
                config.CreateMap<Core.Models.Company, Company>()
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
            services.AddInvSys(Configuration);

            services.AddDbContext<CompaniesContext>();
            services.AddTransient<CompaniesContextSeedData>();
            services.AddScoped<ICompaniesService, CompaniesService>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CompaniesContextSeedData seeder)
        {

            app.UseInvSys(Configuration, loggerFactory);

            seeder.EnsureSeedData().Wait();
        }
    }
}
