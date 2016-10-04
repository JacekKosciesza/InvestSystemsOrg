using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.StockQuotes.Core.Models;
using InvSys.StockQuotes.Core.State;
using InvSys.StockQuotes.Core.Yahoo.Finance;

namespace InvSys.StockQuotes.Core.Services
{
    public class StockQuotesService : IStockQuotesService
    {
        private readonly IHistoricalQuotesRepository _historicalQuotesRepository;
        private readonly IYahooFinanceService _yahooFinanceService;

        public StockQuotesService(IHistoricalQuotesRepository historicalQuotesRepository, IYahooFinanceService yahooFinanceService)
        {
            _historicalQuotesRepository = historicalQuotesRepository;
            _yahooFinanceService = yahooFinanceService;
        }

        public async Task<ICollection<HistoricalQuote>> GetHistoricalQuotes(string stockExchange, string companySymbol, DateTime? startDate, DateTime? endDate)
        {
            
            var dailyPrices = await _historicalQuotesRepository.GetDailyPrices($"{stockExchange}:{companySymbol}", startDate, endDate);
            if (dailyPrices != null && dailyPrices.Any())
            {
                return dailyPrices;
            }
            
            // get whole date range of data from Yahoo Finance and save it to database
            var yahooDailyPrices = await _yahooFinanceService.GetDailyHistoricalPriceData(stockExchange, companySymbol);
            _historicalQuotesRepository.AddRange(yahooDailyPrices);
            await _historicalQuotesRepository.SaveChangesAsync();

            // filter by date
            var q = yahooDailyPrices.AsQueryable();
            if (startDate != null)
            {
                q = q.Where(hq => hq.Date >= startDate.Value);
            }

            if (endDate != null)
            {
                q = q.Where(hq => hq.Date <= endDate.Value);
            }
            return q.OrderBy(p => p.Date).ToList();
        }

        public async Task<CurrentQuote> GetCurrentQuote(string companySymbol)
        {
            var current = await _yahooFinanceService.GetQuote(companySymbol);

            return current;
        }
    }
}
