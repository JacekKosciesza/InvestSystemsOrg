using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvSys.RuleOne.Core.Models.ThreeTools
{
    public class MACDData
    {
        public int Id { get; set; }
        public string CompanySymbol { get; set; }
        public DateTime Date { get; set; }
        public decimal MACD { get; set; }
        public decimal Signal { get; set; }
        public decimal Histogram { get; set; }

        // ---
        public decimal Price { get; set; } // Close price
        public decimal PriceSum { get; set; }
        public decimal PriceAverage { get; set; }
        public decimal EMA12Day { get; set; }
        public decimal EMA26Day { get; set; }
        public decimal MACDSum { get; set; }
        public decimal MACDAverage { get; set; }
    }
}
