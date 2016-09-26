using System;
using System.Collections.Generic;
using System.Linq;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.StockQuotes.Api.Client.Proxy.Models;

namespace InvSys.RuleOne.Core.Services.ThreeTools
{
    // MACD - Moving Average Convergence Divergence
    // http://investexcel.net/how-to-calculate-macd-in-excel/
    public class MACDService : IMACDService
    {
        public ICollection<MACDData> Calculate(ICollection<HistoricalQuote> prices, int param1, int param2, int param3)
        {
            var entries = prices.Select(p => new MACDData { Date = p.Date.Value, Price = (decimal)p.Close.Value }).ToList(); // TODO: swagger and decimal (https://github.com/Azure/autorest/issues/83)
            entries.Insert(0, new MACDData { Date = new DateTime(1900, 1, 1), Price = 0 });
            for (var index = 1; index < entries.Count; index++)
            {
                var previousValue = entries[index - 1];
                var currentValue = entries[index];

                currentValue.PriceSum = previousValue.PriceSum + currentValue.Price;
                currentValue.PriceAverage = currentValue.PriceSum / index;

                // 12 Day EMA
                if (index == param1)
                {
                    currentValue.EMA12Day = currentValue.PriceAverage;
                }
                else if (index > param1)
                {
                    currentValue.EMA12Day = currentValue.Price * ((decimal)2 / (param1 + 1)) + previousValue.EMA12Day * (1 - (decimal)2 / (param1 + 1));
                }

                // 26 Day EMA
                if (index == param2)
                {
                    currentValue.EMA26Day = currentValue.PriceAverage;
                }
                else if (index > param2)
                {
                    currentValue.EMA26Day = currentValue.Price * ((decimal)2 / (param2 + 1)) + previousValue.EMA26Day * (1 - (decimal)2 / (param2 + 1));
                }

                // MCDA
                if (index >= param2)
                {
                    currentValue.MACD = currentValue.EMA12Day - currentValue.EMA26Day;
                    currentValue.MACDSum = previousValue.MACDSum + currentValue.MACD;
                    currentValue.MACDAverage = currentValue.MACDSum / (index - param2 + 1);
                }

                // Signal
                if (index == (param2 + param3 - 1))
                {
                    currentValue.Signal = currentValue.MACDAverage;
                }
                else if (index > (param2 + param3 - 1))
                {
                    currentValue.Signal = currentValue.MACD * ((decimal)2 / (param3 + 1)) + previousValue.Signal * (1 - (decimal)2 / (param3 + 1));
                }

                // Histogram
                if (index >= (param2 + param3 - 1))
                {
                    currentValue.Histogram = currentValue.MACD- currentValue.Signal;
                }
            }

            return entries.Where(e => e.MACD != 0 && e.Signal != 0).OrderBy(e => e.Date).ToList();
        }
    }
}
