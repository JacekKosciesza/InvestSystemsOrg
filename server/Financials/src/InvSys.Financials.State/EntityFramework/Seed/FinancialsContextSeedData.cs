using System;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;

namespace InvSys.Financials.State.EntityFramework.Seed
{
    public class WatchlistsContextSeedData
    {
        private readonly FinancialsContext _dbContext;

        public WatchlistsContextSeedData(FinancialsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task EnsureSeedData()
        {
            if (!_dbContext.BalanceSheets.Any())
            {
                var balanceSheet = new BalanceSheet
                {
                    Id = Guid.NewGuid(),
                };
                _dbContext.BalanceSheets.Add(balanceSheet);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
