using System;

namespace InvSys.RuleOne.Api.Models
{
    public class EMAData
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal EMA { get; set; }
    }
}
