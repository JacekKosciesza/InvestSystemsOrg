using System;
using InvSys.StockQuotes.Api.Client.Proxy.Models;

namespace InvSys.RuleOne.Core.Models.ThreeTools
{
    public class StochasticData
    {
        public int Id { get; set; }
        public string CompanySymbol { get; set; }
        public DateTime Date { get; set; }
        public decimal PercentK { get; set; }
        public decimal PercentD { get; set; }

        // ---
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal HighestHigh { get; set; }
        public decimal LowestLow { get; set; }

        public StochasticData()
        {
            Date = DateTime.MinValue;
            Open = 0;
            High = 0;
            Low = 0;
            Close = 0;
        }

        // TODO: swagger and decimal (https://github.com/Azure/autorest/issues/83)
        public StochasticData(HistoricalQuote hq)
        {
            Date = hq.Date.Value;
            Open = (decimal) hq.Open.Value;
            High = (decimal)hq.High.Value;
            Low = (decimal)hq.Low.Value;
            Close = (decimal)hq.Close.Value;
        }
    }
}
