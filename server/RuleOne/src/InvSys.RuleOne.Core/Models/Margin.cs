using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvSys.RuleOne.Core.Models
{
    public class Margin
    {
        public StickerPrice StickerPrice { get; set; }
        public decimal MOSPrice { get; set; } // Margin Of Safty Price
        public decimal FutureStockPrice { get; set; } // 10 years from now
    }
}
