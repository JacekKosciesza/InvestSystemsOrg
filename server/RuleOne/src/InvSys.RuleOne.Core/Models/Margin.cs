using System;

namespace InvSys.RuleOne.Core.Models
{
    public class Margin
    {
        // margin
        public double? StickerPrice
        {
            get
            {
                if (FutureMarketPrice.HasValue && EPSGrowthRate.HasValue && Years.HasValue)
                {
                    return FutureMarketPrice.Value / Math.Pow(1 + EPSGrowthRate.Value, Years.Value);
                }

                return null;
            }
        }

        public double? MarginOfSafety
        {
            get
            {
                if (StickerPrice.HasValue)
                {
                    return StickerPrice.Value/2;
                }

                return null;
            }
        }

        public double? CurrentPrice { get; set; }

        // calculations
        public double? EPSFuture
        {
            get
            {
                if (EPSCurrent.HasValue && EPSGrowthRate.HasValue && Years.HasValue)
                {
                    return EPSCurrent.Value*Math.Pow(1 + EPSGrowthRate.Value, Years.Value);
                }

                return null;
            }
        }

        public double? FutureMarketPrice
        {
            get
            {
                if (EPSFuture.HasValue && PEFutureEstimated.HasValue)
                {
                    return EPSFuture.Value*PEFutureEstimated;
                }

                return null;
            }
        }

        // pre-calculated data
        public double? EPSCurrent { get; set; }
        public double? EPSGrowthRate => EPSGrowthRateRuleOne;
        public double? PEFutureEstimated => PEFutureEstimatedRuleOne;
        public double? RateOfReturn { get; set; }
        public int? Years { get; set; }

        // data
        public double? EPSGrowthRateAnalysts { get; set; }
        public double? EPSGrowthRateHistorical { get; set; }

        public double? EPSGrowthRateRuleOne
        {
            get
            {
                if (EPSGrowthRateAnalysts.HasValue && EPSGrowthRateHistorical.HasValue)
                {
                    return Math.Min(EPSGrowthRateAnalysts.Value, EPSGrowthRateHistorical.Value);
                }

                return EPSGrowthRateAnalysts ?? EPSGrowthRateHistorical;
            }
        }

        public double? PEFutureEstimatedDefault { get; set; }
        public double? PEFutureEstimatedHistorical { get; set; }

        public double? PEFutureEstimatedRuleOne
        {
            get
            {
                if (PEFutureEstimatedDefault.HasValue && PEFutureEstimatedHistorical.HasValue)
                {
                    return Math.Min(PEFutureEstimatedDefault.Value, PEFutureEstimatedHistorical.Value);
                }

                return PEFutureEstimatedDefault ?? PEFutureEstimatedHistorical;
            }
        }
    }
}
