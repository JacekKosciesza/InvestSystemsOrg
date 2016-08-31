using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using InvSys.Shared.Api.Startup;
using InvSys.Watchlists.Api.Models;
using InvSys.Watchlists.Core.Services;
using InvSys.Watchlists.Core.State;
using InvSys.Watchlists.State.EntityFramework;
using InvSys.Watchlists.State.EntityFramework.Repositories;
using InvSys.Watchlists.State.EntityFramework.Seed;
using Watchlist = InvSys.Watchlists.Api.Models.Watchlist;

namespace InvSys.Watchlists.Api
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
                config.CreateMap<Watchlist, Core.Models.Watchlist>()
                    .ForMember(d => d.Translations, opt => opt.MapFrom(s =>
                        new List<Core.Models.WatchlistTranslation> { new Core.Models.WatchlistTranslation { Culture = s.Culture ?? CultureInfo.CurrentCulture.Name, Description = s.Description }
                    }));
                config.CreateMap<Core.Models.Watchlist, Watchlist>()
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

            services.AddDbContext<WatchlistsContext>();
            services.AddTransient<WatchlistsContextSeedData>();
            services.AddScoped<IWatchlistsService, WatchlistsService>();
            services.AddScoped<IWatchlistsRepository, WatchlistsRepository>();
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, WatchlistsContextSeedData seeder)
        {
            app.UseInvSys(Configuration, loggerFactory);

            seeder.EnsureSeedData().Wait();
        }
    }
}
