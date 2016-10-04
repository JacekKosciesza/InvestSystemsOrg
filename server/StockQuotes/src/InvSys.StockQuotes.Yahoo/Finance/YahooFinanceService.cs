using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.StockQuotes.Core.Models;
using InvSys.StockQuotes.Core.Yahoo.Finance;
using Microsoft.Extensions.Logging;
using YahooFinance.NET;
using YSQ.core.Quotes;

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

        public Task<CurrentQuote> GetQuote(string companySymbol)
        {
            //Create the quote service
            var quoteService = new QuoteService();

            //Get a quote
            var find = quoteService.Quote(companySymbol);
            var quotes = find.Return(
                QuoteReturnParameter.Symbol,
                QuoteReturnParameter.Name,
                QuoteReturnParameter.LatestTradePrice,
                QuoteReturnParameter.EPS,
                QuoteReturnParameter.EPSEstimateCurrentYear,
                QuoteReturnParameter.EPSEstimateNextYear,
                QuoteReturnParameter.PERatio,
                QuoteReturnParameter.PEGRatio);

            var currentQuote = new CurrentQuote
            {
                Symbol = quotes.Symbol.ToString().Trim('"'),
                Name = quotes.Name.ToString().Trim('"'),
                LatestTradePrice = double.Parse(quotes.LatestTradePrice, CultureInfo.InvariantCulture),
                EPS = double.Parse(quotes.EPS, CultureInfo.InvariantCulture),
                EPSEstimateCurrentYear = double.Parse(quotes.EPSEstimateCurrentYear, CultureInfo.InvariantCulture),
                EPSEstimateNextYear = double.Parse(quotes.EPSEstimateNextYear, CultureInfo.InvariantCulture),
                PERatio = double.Parse(quotes.PERatio, CultureInfo.InvariantCulture),
                PEGRatio = double.Parse(quotes.PEGRatio, CultureInfo.InvariantCulture)
            };

            return Task.FromResult(currentQuote);
        }
    }
}
