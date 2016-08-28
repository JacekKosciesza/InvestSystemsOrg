using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.Email.Core.Models;
using InvSys.Email.Core.Services;
using InvSys.Email.Core.State;
using InvSys.Email.State.EntityFramework;
using InvSys.Email.State.EntityFramework.Repositories;
using InvSys.Email.State.EntityFramework.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using InvSys.Shared.Api.Startup;
using Template = InvSys.Email.Api.Models.Template;

namespace InvSys.Email.Api
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
                config.CreateMap<Template, Core.Models.Template>()
                    .ForMember(d => d.Translations, opt => opt.MapFrom(s =>
                        new List<TemplateTranslation> { new TemplateTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Description = s.Description }
                    }));
                config.CreateMap<Core.Models.Template, Template>()
                    .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Description))
                    .ForMember(d => d.Culture, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Culture))
                    .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Title))
                    .ForMember(d => d.Body, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Body));
                config.AllowNullCollections = true;
            });
        }

        public IConfigurationRoot Configuration { get; }
        private readonly MapperConfiguration _mapperConfiguration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInvSys(Configuration);

            services.AddDbContext<EmailContext>();
            services.AddTransient<EmailContextSeedData>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITemplatesRepository, TemplatesRepository>();
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, EmailContextSeedData seeder)
        {
            app.UseInvSys(Configuration, loggerFactory);

            seeder.EnsureSeedData().Wait();
        }
    }
}
