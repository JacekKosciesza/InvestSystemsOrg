namespace InvSys.RuleOne.Core.Models
{
    public class Margin
    {
        // margin
        public decimal? StickerPrice { get; set; }
        public decimal? MarginOfSafety { get; set; }

        // calculations
        public double? EPSFuture { get; set; }
        public decimal? FutureMarketPrice { get; set; }

        // pre-calculated data
        public double? EPSCurrent { get; set; }
        public double? EPSGrowthRate { get; set; }
        public double? PEFutureEstimated { get; set; }
        public double? RateOfReturn { get; set; }
        public int? Years { get; set; }

        // data
        public double? EPSGrowthRateAnalysts { get; set; }
        public double? EPSGrowthRateHistorical { get; set; }
        public double? EPSGrowthRateRuleOne { get; set; }
        public double? PEFutureEstimatedDefault { get; set; }
        public double? PEFutureEstimatedHistorical { get; set; }
        public double? PEFutureEstimatedRuleOne { get; set; }
    }
}
