using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;

namespace InvSys.Financials.State.EntityFramework.Seed
{
    public class FinancialsContextSeedData
    {
        private readonly FinancialsContext _db;

        public FinancialsContextSeedData(FinancialsContext financialsContext)
        {
            _db = financialsContext;
        }

        public async Task EnsureSeedData()
        {
            if (!_db.Data.Any())
            {
                var financialData = new List<FinancialData>
                {
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2015,
                        Currency = "USD",
                        Revenue = 2820.3M,
                        EPS = 2.39,
                        Equity = 3345.1M,
                        Cash = 180.3M,
                        ROIC = 0.1020
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2014,
                        Currency = "USD",
                        Revenue = 2870.7M,
                        EPS = 1.89,
                        Equity = 3403.4M,
                        Cash = 702.8M,
                        ROIC = 0.1220
                    }
                };
                    
                _db.Data.AddRange(financialData);
                await _db.SaveChangesAsync();
            }
        }
    }
}
