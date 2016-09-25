using System.Collections.Generic;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.StockQuotes.Api.Client.Proxy.Models;

namespace InvSys.RuleOne.Core.Services.ThreeTools
{
    // Stochastic Oscillator
    // http://investexcel.net/how-to-calculate-the-stochastic-oscillator/
    public interface IStochasticService
    {
        ICollection<StochasticData> Calculate(ICollection<HistoricalQuote> prices, int param1, int param2);
    }
}
