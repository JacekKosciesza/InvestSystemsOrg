using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Shared.State.EntityFramework.Repositories;
using InvSys.StockQuotes.Core.Models;
using InvSys.StockQuotes.Core.State;
using Microsoft.EntityFrameworkCore;

namespace InvSys.StockQuotes.State.EntityFramework.Repositories
{
    public class HistoricalQuotesRepository : BaseRepository<HistoricalQuote, int>, IHistoricalQuotesRepository
    {
        private readonly StockQuotesContext _stockQuotesContext;
        public HistoricalQuotesRepository(StockQuotesContext dbContext)
            : base(dbContext)
        {
            _stockQuotesContext = dbContext;
        }

        public async Task<ICollection<HistoricalQuote>> GetDailyPrices(string symbol, DateTime? startDate, DateTime? endDate)
        {
            var q = from hq in _stockQuotesContext.HistoricalQuotes
                where hq.Symbol == symbol
                select hq;

            if (startDate != null)
            {
                q = q.Where(hq => hq.Date >= startDate.Value);
            }

            if (endDate != null)
            {
                q = q.Where(hq => hq.Date <= endDate.Value);
            }

            return await q.ToListAsync();
        }
    }
}
