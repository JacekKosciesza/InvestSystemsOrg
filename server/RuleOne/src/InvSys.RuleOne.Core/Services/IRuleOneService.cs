using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.Shared.Core.Model;

namespace InvSys.RuleOne.Core.Services
{
    public interface IRuleOneService
    {
        Task<List<Rating>> GetRatings();
        Task<Page<Rating>> GetPageOfRatings(Query query);
        Task<List<Rating>> GetRatings(IEnumerable<string> companySymbols);
    }
}
