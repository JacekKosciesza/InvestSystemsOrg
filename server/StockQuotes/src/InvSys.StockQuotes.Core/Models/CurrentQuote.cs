using System;
using InvSys.Shared.Core.State;

namespace InvSys.StockQuotes.Core.Models
{
    public class CurrentQuote : IEntity<int>
    {
        public int Id { get; set; }

        public string Symbol { get; set; }
        public string AverageDailyVolume { get; set; }
        public string Change { get; set; }
        public string DaysLow { get; set; }
        public string DaysHigh { get; set; }
        public string YearLow { get; set; }
        public string YearHigh { get; set; }
        public string MarketCapitalization { get; set; }
        public string LastTradePriceOnly { get; set; }
        public string DaysRange { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        public string StockExchange { get; set; }
    }
}
