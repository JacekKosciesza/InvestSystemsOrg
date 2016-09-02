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
            
            var yahooDailyPrices = await _yahooFinanceService.GetDailyHistoricalPriceData(stockExchange, companySymbol, startDate, endDate);
            _historicalQuotesRepository.AddRange(yahooDailyPrices);
            await _historicalQuotesRepository.SaveChangesAsync();

            return yahooDailyPrices;
        }
    }
}
