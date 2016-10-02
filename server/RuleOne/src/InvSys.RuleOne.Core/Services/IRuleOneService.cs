using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.Management;
using InvSys.RuleOne.Core.Models.Moats;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.Shared.Core.Model;

namespace InvSys.RuleOne.Core.Services
{
    public interface IRuleOneService
    {
        // Rating
        Task<List<Rating>> GetRatings();
        Task<Page<Rating>> GetPageOfRatings(Query query);
        Task<List<Rating>> GetRatings(IEnumerable<string> companySymbols);

        // Meaning
        Task<Meaning> GetMeaning(string companySymbol, Guid userId);

        // Moat
        Task<Moat> GetMoat(string companySymbol);

        // Management
        Task<List<Leader>> GetManagement(string companySymbol);

        // Three Tools
        Task<ICollection<EMAData>> GetEMA(string companySymbol, int? days);
        Task<ICollection<MACDData>> GetMACD(string companySymbol, int? days);
        Task<ICollection<StochasticData>> GetStochastic(string companySymbol, int? days);
    }
}
