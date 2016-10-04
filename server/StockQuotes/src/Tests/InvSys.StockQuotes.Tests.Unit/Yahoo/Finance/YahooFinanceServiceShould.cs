using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.StockQuotes.Core.Services;
using InvSys.StockQuotes.Core.State;
using InvSys.StockQuotes.Core.Yahoo.Finance;
using InvSys.StockQuotes.State.EntityFramework;
using InvSys.StockQuotes.State.EntityFramework.Repositories;
using InvSys.StockQuotes.Yahoo.Finance;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace InvSys.StockQuotes.Tests.Unit.Yahoo.Finance
{
    public class YahooFinanceServiceShould
    {
        IServiceCollection _serviceCollection; // https://msdn.microsoft.com/en-us/magazine/mt707534.aspx
        public IServiceProvider Services { get; set; }

        private readonly MapperConfiguration _mapperConfiguration;

        public YahooFinanceServiceShould()
        {
            _mapperConfiguration = new MapperConfiguration(StockQuotes.Api.Mapper.Configure);
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // TOOD: take this configuration from Api's Startup.cs?
            services.AddDbContext<StockQuotesContext>();
            services.AddScoped<IStockQuotesService, StockQuotesService>();
            services.AddScoped<IHistoricalQuotesRepository, HistoricalQuotesRepository>();
            services.AddScoped<IYahooFinanceService, YahooFinanceService>();
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        [Fact]
        public void GetQuote()
        {
            // Arrange
            var yahooFinanceService = Services.GetRequiredService<IYahooFinanceService>();

            // Act
            yahooFinanceService.GetQuote("MSFT");

            // Assert
        }
    }
}
