using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Api.Client.Proxy.Models;
using InvSys.RuleOne.Core.Models.Moats;

namespace InvSys.RuleOne.Core.Services.Moats
{
    public interface IBigFiveGrowthRateService
    {
        Task<List<BigFiveGrowthRate>> Calculate(ICollection<FinancialData> financialData, int[] years);
        double? GrowthRate(double? future, double? past, int years);
    }
}
