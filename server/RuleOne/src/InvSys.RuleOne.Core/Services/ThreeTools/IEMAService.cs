using System.Collections.Generic;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.StockQuotes.Api.Client.Proxy.Models;

namespace InvSys.RuleOne.Core.Services
{
    // EMA - Exponential Moving Average
    // http://investexcel.net/how-to-calculate-ema-in-excel/
    public interface IEMAService
    {
        ICollection<EMAData> Calculate(ICollection<HistoricalQuote> prices, int days);
    }
}
