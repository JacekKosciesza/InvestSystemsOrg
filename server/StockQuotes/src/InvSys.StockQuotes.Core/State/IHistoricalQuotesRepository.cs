using System;
using System.Threading.Tasks;
using InvSys.Shared.Core.State;
using InvSys.StockQuotes.Core.Models;
using System.Collections.Generic;

namespace InvSys.StockQuotes.Core.State
{
    public interface IHistoricalQuotesRepository : IBaseRepository<HistoricalQuote, int>
    {
        Task<ICollection<HistoricalQuote>> GetDailyPrices(string symbol, DateTime? startDate, DateTime? endDate);
    }
}
