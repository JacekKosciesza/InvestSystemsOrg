using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.StockQuotes.Core.Models;

namespace InvSys.StockQuotes.Core.Yahoo.Finance
{
    public interface IYahooFinanceService
    {
        Task<ICollection<HistoricalQuote>> GetDailyHistoricalPriceData(string stockExchange, string companySymbol, DateTime? startDate = null, DateTime? endDate = null);
        Task<CurrentQuote> GetQuote(string companySymbol);
    }
}
