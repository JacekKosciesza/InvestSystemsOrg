using System;
using InvSys.Shared.Core.State;

namespace InvSys.StockQuotes.Core.Models
{
    public class HistoricalQuote : IEntity<int>
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public decimal AdjClose { get; set; }

    }
}
