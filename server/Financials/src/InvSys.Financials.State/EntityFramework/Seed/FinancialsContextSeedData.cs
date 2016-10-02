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
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2013,
                        Currency = "USD",
                        Revenue = 2631.9M,
                        EPS = 3.13,
                        Equity = 3659.7M,
                        Cash = 284.5M,
                        ROIC = 0.1000
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2012,
                        Currency = "USD",
                        Revenue = 2715.7M,
                        EPS = 2.78,
                        Equity = 3531.8M,
                        Cash = 527.5M,
                        ROIC = 0.1110
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2011,
                        Currency = "USD",
                        Revenue = 2758.6M,
                        EPS = 2.68,
                        Equity = 3256.6M,
                        Cash = 661.7M,
                        ROIC = 0.1100
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2010,
                        Currency = "USD",
                        Revenue = 2689.9M,
                        EPS = 2.97,
                        Equity = 3049.6M,
                        Cash = 550.7M,
                        ROIC = 0.1350
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2009,
                        Currency = "USD",
                        Revenue = 2946.4M,
                        EPS = 3.51,
                        Equity = 2836.4M,
                        Cash = 771.6M,
                        ROIC = 0.1940
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2008,
                        Currency = "USD",
                        Revenue = 3497.1M,
                        EPS = 3.51,
                        Equity = 2225.9M,
                        Cash = 518.7M,
                        ROIC = 0.2350
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2007,
                        Currency = "USD",
                        Revenue = 3180.3M,
                        EPS = 3.95,
                        Equity = 2350.6M,
                        Cash = 128.9M,
                        ROIC = 0.2900
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2006,
                        Currency = "USD",
                        Revenue = 1774M,
                        EPS = 2.38,
                        Equity = 1557.9M,
                        Cash = 125.2M,
                        ROIC = 0.2550
                    },
                    new FinancialData
                    {
                        CompanySymbol = "GRMN",
                        Year = 2005,
                        Currency = "USD",
                        Revenue = 1027.8M,
                        EPS = 1.44,
                        Equity = 1157.3M,
                        Cash = 132.3M,
                        ROIC = 0.2020
                    }
                };
                    
                _db.Data.AddRange(financialData);
                await _db.SaveChangesAsync();
            }
        }
    }
}
