using System;
using AutoMapper;
using InvSys.Companies.Api.Client.Proxy;
using InvSys.Gateway.Core.GraphQLTest;
using InvSys.Gateway.Core.Services;
using InvSys.Portfolios.Api.Client.Proxy;
using InvSys.RuleOne.Api.Client.Proxy;
using InvSys.Shared.Api.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using InvSys.Watchlists.Api.Client.Proxy;

namespace InvSys.Gateway.Api
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

            _mapperConfiguration = new MapperConfiguration(Mapper.Configure);
        }

        public IConfigurationRoot Configuration { get; }
        private readonly MapperConfiguration _mapperConfiguration;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInvSys(Configuration);

            services.AddTransient<IStarWarsGraphQL, StarWarsGraphQL>();
            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<IWatchlistsService, WatchlistsService>();
            services.AddTransient<IPortfoliosService, PortfoliosService>();
            services.AddTransient<ICompaniesAPI, CompaniesAPI>(x => new CompaniesAPI(new Uri(Configuration["APIs:Companies:Url"], UriKind.Absolute)));
            services.AddTransient<IRuleOneAPI, RuleOneAPI>(x => new RuleOneAPI(new Uri(Configuration["APIs:RuleOne:Url"], UriKind.Absolute)));
            services.AddTransient<IWatchlistsAPI, WatchlistsAPI>(x => new WatchlistsAPI(new Uri(Configuration["APIs:Watchlists:Url"], UriKind.Absolute)));
            services.AddTransient<IPortfoliosAPI, PortfoliosAPI>(x => new PortfoliosAPI(new Uri(Configuration["APIs:Portfolios:Url"], UriKind.Absolute)));
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseInvSys(Configuration, loggerFactory);
        }
    }
}
