using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvSys.RuleOne.Core.Models.Moats
{
    public class BigFiveGrowthRate
    {
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }

        public double? Sales { get; set; }
        public double? EPS { get; set; }
        public double? Equity { get; set; }
        public double? Cash { get; set; }
        public double? ROIC { get; set; }
    }
}
