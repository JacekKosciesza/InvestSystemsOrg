using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvSys.RuleOne.Core.Models
{
    public class StickerPrice
    {
        public double CurrentEPS { get; set; } // Current EPS (Eearnings Per Share)
        public double EstimatedEPSGrowthRate { get; set; } // Estimated (future) EPS growth rate
        public double EstimatedFuturePE { get; set; } // Estimated future PE (Price/Earnings)
        public double MinimalROI { get; set; } // Mimimum acceptable rate of return from this investment
    }
}
