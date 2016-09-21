using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.State;
using InvSys.Shared.Core.Model;

namespace InvSys.RuleOne.Core.Services
{
    public class RuleOneService : IRuleOneService
    {
        private readonly IRatingsRepository _repo;

        public RuleOneService(IRatingsRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Rating>> GetRatings()
        {
            return _repo.GetAll();
        }

        public Task<Page<Rating>> GetPageOfRatings(Query query)
        {
            return _repo.GetPage(query);
        }

        public Task<List<Rating>> GetRatings(IEnumerable<string> companySymbols)
        {
            return _repo.Get(companySymbols);
        }

        public Task<Rating> GetRating(string companySymbol)
        {
            return _repo.Get(companySymbol);
        }
    }
}
