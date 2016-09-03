using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.Portfolios.Api.Models;
using InvSys.Portfolios.Core.Services;
using InvSys.Portfolios.Core.State;
using InvSys.Portfolios.State.EntityFramework;
using InvSys.Portfolios.State.EntityFramework.Repositories;
using InvSys.Portfolios.State.EntityFramework.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using InvSys.Shared.Api.Startup;

namespace InvSys.Portfolios.Api
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
                config.CreateMap<Portfolio, Core.Models.Portfolio>()
                    .ForMember(d => d.Translations, opt => opt.MapFrom(s =>
                        new List<Core.Models.PortfolioTranslation> { new Core.Models.PortfolioTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Description = s.Description }
                    }));
                config.CreateMap<Core.Models.Portfolio, Portfolio>()
                    .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Description))
                    .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Name))
                    .ForMember(d => d.Culture, opt => opt.MapFrom(s => s.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name).Culture));
                config.CreateMap<Core.Models.Item, Item>(MemberList.Destination);
                config.CreateMap<Item, Core.Models.Item>(MemberList.Source);
                config.AllowNullCollections = true;
            });
        }

        public IConfigurationRoot Configuration { get; }
        private readonly MapperConfiguration _mapperConfiguration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInvSys(Configuration);

            services.AddDbContext<PortfoliosContext>();
            services.AddTransient<PortfoliosContextSeedData>();
            services.AddScoped<IPortfoliosService, PortfoliosService>();
            services.AddScoped<IPortfoliosRepository, PortfoliosRepository>();
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, PortfoliosContextSeedData seeder)
        {
            app.UseInvSys(Configuration, loggerFactory);

            seeder.EnsureSeedData().Wait();
        }
    }
}
