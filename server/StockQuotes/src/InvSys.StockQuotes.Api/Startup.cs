using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using InvSys.Shared.Api.Startup;
using InvSys.StockQuotes.Core.Models;
using InvSys.StockQuotes.Core.Services;
using InvSys.StockQuotes.Core.State;
using InvSys.StockQuotes.Core.Yahoo.Finance;
using InvSys.StockQuotes.State.EntityFramework;
using InvSys.StockQuotes.State.EntityFramework.Repositories;
using InvSys.StockQuotes.Yahoo.Finance;
using YahooFinance.NET;

namespace InvSys.StockQuotes.Api
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
                config.CreateMap<YahooHistoricalPriceData, HistoricalQuote>(MemberList.Source);
                config.AllowNullCollections = true;
            });
        }

        public IConfigurationRoot Configuration { get; }
        private readonly MapperConfiguration _mapperConfiguration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInvSys(Configuration);

            services.AddDbContext<StockQuotesContext>();
            services.AddScoped<IStockQuotesService, StockQuotesService>();
            services.AddScoped<IHistoricalQuotesRepository, HistoricalQuotesRepository>();
            services.AddScoped<IYahooFinanceService, YahooFinanceService>();
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseInvSys(Configuration, loggerFactory);
        }
    }
}
