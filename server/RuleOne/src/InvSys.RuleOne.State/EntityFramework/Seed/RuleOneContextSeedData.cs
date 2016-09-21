using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;

namespace InvSys.RuleOne.State.EntityFramework.Seed
{
    public class RuleOneContextSeedData
    {
        private readonly RuleOneContext _db;

        public RuleOneContextSeedData(RuleOneContext financialsContext)
        {
            _db = financialsContext;
        }

        public async Task EnsureSeedData()
        {
            if (!_db.Ratings.Any())
            {
                var ratings = new List<Rating>
                {
                    new Rating
                    {
                        CompanySymbol = "MENT",
                        Date = DateTime.Now.AddDays(-1),
                        IsAwesome = true
                    },
                    new Rating
                    {
                        CompanySymbol = "MENT",
                        Date = DateTime.Now,
                        IsAwesome = false
                    },
                    new Rating
                    {
                        CompanySymbol = "EPAM",
                        Date = DateTime.Now.AddDays(-1),
                        IsAwesome = false
                    },
                    new Rating
                    {
                        CompanySymbol = "EPAM",
                        Date = DateTime.Now,
                        IsAwesome = true
                    },
                };
                    
                _db.Ratings.AddRange(ratings);
                await _db.SaveChangesAsync();
            }
        }
    }
}
