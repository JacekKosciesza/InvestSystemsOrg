using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Portfolios.Core.Models;

namespace InvSys.Portfolios.State.EntityFramework.Seed
{
    public class PortfoliosContextSeedData
    {
        private readonly PortfoliosContext _dbContext;

        public PortfoliosContextSeedData(PortfoliosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task EnsureSeedData()
        {
            if (!_dbContext.Portfolios.Any())
            {
                var portfolio = new Portfolio
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("c6c746fd-e2da-4f3b-8417-6b7716421133"),
                    UserName = "jkosciesza",
                    Translations = new List<PortfolioTranslation>
                    {
                        new PortfolioTranslation
                        {
                            Culture = "en-US",
                            Description = "List of my companies",
                            Name = "My companies"
                        },
                        new PortfolioTranslation
                        {
                            Culture = "pl-PL",
                            Description = "Lista moich firm",
                            Name = "Moje firmy"
                        }
                    },
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            CompanyId = new Guid("9BE7489D-50D4-42AC-81D9-1B53A25FAD65"),
                            CompanySymbol = "MENT"
                        }
                    }
                };
                _dbContext.Portfolios.Add(portfolio);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}