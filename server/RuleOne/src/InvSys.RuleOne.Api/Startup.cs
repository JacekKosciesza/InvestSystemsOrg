using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.RuleOne.Core.Services;
using InvSys.RuleOne.Core.Services.ThreeTools;
using InvSys.RuleOne.Core.State;
using InvSys.RuleOne.State.EntityFramework;
using InvSys.RuleOne.State.EntityFramework.Repositories;
using InvSys.RuleOne.State.EntityFramework.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using InvSys.Shared.Api.Startup;
using InvSys.StockQuotes.Api.Client.Proxy;

namespace InvSys.RuleOne.Api
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

            services.AddDbContext<RuleOneContext>();
            services.AddTransient<RuleOneContextSeedData>();
            services.AddScoped<IRuleOneService, RuleOneService>();
            services.AddScoped<IEMAService, EMAService>();
            services.AddScoped<IMACDService, MACDService>();
            services.AddScoped<IStochasticService, StochasticService>(); 
            services.AddScoped<IRatingsRepository, RatingsRepository>();
            services.AddScoped<IStockQuotesAPI, StockQuotesAPI>(x => new StockQuotesAPI(new Uri(Configuration["APIs:StockQuotes:Url"], UriKind.Absolute)));
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, RuleOneContextSeedData seeeder)
        {
            app.UseInvSys(Configuration, loggerFactory);

            seeeder.EnsureSeedData().Wait();
        }
    }
}
