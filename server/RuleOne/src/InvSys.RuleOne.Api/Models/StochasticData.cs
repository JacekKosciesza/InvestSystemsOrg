using System;

namespace InvSys.RuleOne.Api.Models
{
    public class StochasticData
    {
        public DateTime Date { get; set; }
        public decimal PercentK { get; set; }
        public decimal PercentD { get; set; }
    }
}
