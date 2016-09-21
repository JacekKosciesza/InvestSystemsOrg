using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.State
{
    public interface IRatingsRepository : IBaseRepository<Rating, Guid>
    {
        Task<Page<Rating>> GetPage(Query query);
        Task<Rating> Get(string companySymbol);
        Task<List<Rating>> Get(IEnumerable<string> companySymbols);
    }
}
