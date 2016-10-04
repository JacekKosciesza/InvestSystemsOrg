namespace InvSys.StockQuotes.Core.Models
{
    public class CurrentQuote
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double LatestTradePrice { get; set; }
        public double EPS { get; set; }
        public double EPSEstimateCurrentYear { get; set; }
        public double EPSEstimateNextYear { get; set; }
        public double PERatio { get; set; }
        public double PEGRatio { get; set; }
    }
}
