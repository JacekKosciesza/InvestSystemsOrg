using System.Collections.Generic;

namespace InvSys.RuleOne.Core.Models.Moats
{
    public class BigFive
    {
        public ICollection<BigFiveAnnual> BigFiveAnnual { get; set; }
        public ICollection<BigFiveGrowthRate> BigFiveGrowthRates { get; set; }
    }
}
