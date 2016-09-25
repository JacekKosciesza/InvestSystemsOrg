using System.Collections.Generic;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.StockQuotes.Api.Client.Proxy.Models;
using System.Linq;

namespace InvSys.RuleOne.Core.Services.ThreeTools
{
    public class StochasticService : IStochasticService
    {
        public ICollection<StochasticData> Calculate(ICollection<HistoricalQuote> prices, int param1, int param2)
        {
            var entries = prices.Select(p => new StochasticData(p)).ToList();
            entries.Insert(0, new StochasticData());
            for (var i = 1; i < entries.Count; i++)
            {
                var previousValue = entries[i - 1];
                var currentValue = entries[i];
                var index = i + 1;

                if (index >= param1)
                {
                    // Highest high & Lowest low
                    var subentries = entries.GetRange(index - param1, param1);
                    currentValue.HighestHigh = subentries.Max(x => x.High);
                    currentValue.LowestLow = subentries.Min(x => x.Low);

                    // %K
                    currentValue.PercentK = (currentValue.Close - currentValue.LowestLow) / (currentValue.HighestHigh - currentValue.LowestLow) * 100;
                }

                // %D
                if (index >= param1 + param2 - 1)
                {
                    var sum = 0m;
                    for (var j = param2 - 1; j >= 0; j--)
                    {
                        sum += entries[index - j - 1].PercentK;
                    }
                    currentValue.PercentD = sum / param2;
                }
            }

            return entries;
        }
    }
}
