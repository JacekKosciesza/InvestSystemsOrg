using System;
using System.Collections.Generic;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.Models.Moats
{
    public class Moat
    {
        public FiveMoats FiveMoats { get; set; }
        public ICollection<BigFive> BigFiveNumbers { get; set; }
        public ICollection<BigFiveGrowthRate> BigFiveGrowthRates { get; set; }
    }
}
