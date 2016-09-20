using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.Shared.Core.Model;

namespace InvSys.RuleOne.Core.Services
{
    public class RuleOneService : IRuleOneService
    {
        // fake data
        readonly List<Rating> _ratings = new List<Rating>
        {
            new Rating { CompanySymbol = "MENT", IsAwsome = false },
            new Rating { CompanySymbol = "EPAM", IsAwsome = true }

        };

        public Task<List<Rating>> GetRatings()
        {
            return Task.FromResult(_ratings);
        }

        public Task<Page<Rating>> GetPageOfRatings(Query query)
        {
            
            var page = new Page<Rating>
            {
                Items = _ratings,
                CurrentPage = 1,
                ItemsPerPage = 10,
                ItemsCount = 2,
                TotalItemsCount = 2,
                TotalPages = 1
            };
            return Task.FromResult(page);
        }

        public Task<Rating> GetRating(string companySymbol)
        {
            switch (companySymbol)
            {
                case "MENT":
                    return Task.FromResult(_ratings[0]);
                case "EPAM":
                    return Task.FromResult(_ratings[1]);
                default:
                    return null;
            }
        }
    }
}
