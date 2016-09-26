using System;

namespace InvSys.RuleOne.Core.Models.ThreeTools
{
    public class EMAData
    {
        public int Id { get; set; }
        public string CompanySymbol { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; } // Close price
        public decimal EMA { get; set; }
        // --
        public decimal PriceSum { get; set; }
        public decimal PriceAverage { get; set; }
    }
}
