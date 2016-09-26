using System;

namespace InvSys.RuleOne.Api.Models
{
    public class MACDData
    {
        public DateTime Date { get; set; }
        public decimal MACD { get; set; }
        public decimal Signal { get; set; }
    }
}
