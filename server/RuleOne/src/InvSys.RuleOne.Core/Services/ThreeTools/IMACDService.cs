using System;
using System.Collections.Generic;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.StockQuotes.Api.Client.Proxy.Models;

namespace InvSys.RuleOne.Core.Services.ThreeTools
{
    // MACD - Moving Average Convergence Divergence
    // http://investexcel.net/how-to-calculate-macd-in-excel/
    public interface IMACDService
    {
        ICollection<MACDData> Calculate(ICollection<HistoricalQuote> prices, int param1, int param2, int param3);
    }
}
