using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Watchlists.Core.Models;

namespace InvSys.Watchlists.State.EntityFramework.Seed
{
    public class WatchlistsContextSeedData
    {
        private readonly WatchlistsContext _dbContext;

        public WatchlistsContextSeedData(WatchlistsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task EnsureSeedData()
        {
            if (!_dbContext.Watchlists.Any())
            {
                var watchlist = new Watchlist
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("c6c746fd-e2da-4f3b-8417-6b7716421133"),
                    UserName = "jkosciesza",
                    Translations = new List<WatchlistTranslation>
                    {
                        new WatchlistTranslation
                        {
                            Culture = "en-US",
                            Description = "List of companies to watch",
                            Name = "Companies with potential"
                        },
                        new WatchlistTranslation
                        {
                            Culture = "pl-PL",
                            Description = "Lista firm do obserwacji",
                            Name = "Firmy z potencjałem"
                        }
                    },
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            CompanyId = new Guid("7448CCD1-486E-46F3-BBF1-4D93CE189B7E"),
                            CompanySymbol = "EPAM"
                        }
                    }
                };
                _dbContext.Watchlists.Add(watchlist);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
