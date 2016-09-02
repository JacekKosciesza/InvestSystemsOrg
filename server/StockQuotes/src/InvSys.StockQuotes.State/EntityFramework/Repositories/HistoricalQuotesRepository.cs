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
            return await _stockQuotesContext.HistoricalQuotes.Where(x => x.Symbol == symbol).ToListAsync(); // TODO: date range
        }
    }
}
