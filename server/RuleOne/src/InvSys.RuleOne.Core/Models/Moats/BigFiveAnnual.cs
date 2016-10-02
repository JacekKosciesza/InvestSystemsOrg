namespace InvSys.RuleOne.Core.Models.Moats
{
    public class BigFiveAnnual
    {
        public int Year { get; set; }

        public string Currency { get; set; }

        // Big Five
        public decimal? Sales { get; set; }
        public double? EPS { get; set; }
        public decimal? Equity { get; set; }
        public decimal? Cash { get; set; }
        public double? ROIC { get; set; }

        // Extra
        public decimal? Debt { get; set; }
        public decimal? Dividends { get; set; }
    }
}
