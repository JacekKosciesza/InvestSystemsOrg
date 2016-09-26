using System;
using System.Collections.Generic;
using System.Linq;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.StockQuotes.Api.Client.Proxy.Models;

namespace InvSys.RuleOne.Core.Services.ThreeTools
{
    // EMA - Exponential Moving Average
    // http://investexcel.net/how-to-calculate-ema-in-excel/
    public class EMAService : IEMAService
    {
        public ICollection<EMAData> Calculate(ICollection<HistoricalQuote> prices, int days)
        {
            var entries = prices.Select(p => new EMAData { Date = p.Date.Value, Price = (decimal)p.Close.Value }).ToList(); // TODO: swagger and decimal (https://github.com/Azure/autorest/issues/83)
            entries.Insert(0, new EMAData { Date = new DateTime(1900, 1, 1), Price = 0 });
            for (var index = 1; index < entries.Count; index++)
            {
                var previousValue = entries[index - 1];
                var currentValue = entries[index];

                currentValue.PriceSum = previousValue.PriceSum + currentValue.Price;
                currentValue.PriceAverage = currentValue.PriceSum / index;

                // x Days EMA
                if (index == days)
                {
                    currentValue.EMA = currentValue.PriceAverage;
                }
                else if (index > days)
                {
                    currentValue.EMA = currentValue.Price * ((decimal)2 / (days + 1)) + previousValue.EMA * (1 - (decimal)2 / (days + 1));
                }
            }

            return entries.Where(e => e.EMA != 0).OrderBy(e => e.Date).ToList();
        }
    }
}
