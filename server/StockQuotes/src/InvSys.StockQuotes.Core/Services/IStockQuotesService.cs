using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.StockQuotes.Core.Models;

namespace InvSys.StockQuotes.Core.Services
{
    public interface IStockQuotesService
    {
        Task<ICollection<HistoricalQuote>> GetHistoricalQuotes(string stockExchange, string companySymbol, DateTime? startDate, DateTime? endDate);
        Task<CurrentQuote> GetCurrentQuote(string companySymbol);
    }
}
