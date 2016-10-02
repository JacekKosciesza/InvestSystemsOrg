using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Financials.Api.Client.Proxy.Models;
using InvSys.RuleOne.Core.Models.Moats;

namespace InvSys.RuleOne.Core.Services.Moats
{
    public class BigFiveGrowthRateService : IBigFiveGrowthRateService
    {
        public Task<List<BigFiveGrowthRate>> Calculate(ICollection<FinancialData> financialData, int[] years)
        {
            var bigFiveGrowthRates = new List<BigFiveGrowthRate>();

            foreach (var year in years.OrderByDescending(y => y))
            {
                if (financialData.Count < year) { continue; }
                var start = financialData.ToArray()[year];
                var end = financialData.ToArray()[0];
                var bfgr = new BigFiveGrowthRate
                {
                    StartYear = start.Year,
                    EndYear = end.Year,
                    Sales = GrowthRate(end.Revenue, start.Revenue, year),
                    EPS = GrowthRate(end.Eps, start.Eps, year),
                    Equity = GrowthRate(end.Equity, start.Equity, year),
                    Cash = GrowthRate(end.Cash, start.Cash, year),
                    ROIC = null // TODO: calculate it
                };
                bigFiveGrowthRates.Add(bfgr);
            }

            return Task.FromResult(bigFiveGrowthRates);
        }

        private double? GrowthRate(double? future, double? past, int years)
        {
            if (!future.HasValue || !past.HasValue) { return null; }
            var growthRate = Math.Pow(future.Value/past.Value, (double) 1/years) - 1;
            return Math.Round(growthRate * 100, 2);
        }
    }
}
