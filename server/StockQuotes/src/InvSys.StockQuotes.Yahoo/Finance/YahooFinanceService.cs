using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.StockQuotes.Core.Models;
using InvSys.StockQuotes.Core.Yahoo.Finance;
using Microsoft.Extensions.Logging;
using YahooFinance.NET;

namespace InvSys.StockQuotes.Yahoo.Finance
{
    public class YahooFinanceService : IYahooFinanceService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<YahooFinanceService> _logger;

        public YahooFinanceService(IMapper mapper, ILogger<YahooFinanceService> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        Task<ICollection<HistoricalQuote>> IYahooFinanceService.GetDailyHistoricalPriceData(string stockExchange, string companySymbol, DateTime? startDate, DateTime? endDate)
        {
            var yahooFinance = new YahooFinanceClient();
            var yahooStockCode = yahooFinance.GetYahooStockCode(stockExchange, companySymbol);
            var yahooPriceHistory = yahooFinance.GetDailyHistoricalPriceData(yahooStockCode);
            
            var priceHistory = _mapper.Map<ICollection<HistoricalQuote>>(yahooPriceHistory);
            foreach (var historicalQuote in priceHistory)
            {
                historicalQuote.Symbol = $"{stockExchange}:{companySymbol}";
            }

            return Task.FromResult(priceHistory);
        }
    }
}
