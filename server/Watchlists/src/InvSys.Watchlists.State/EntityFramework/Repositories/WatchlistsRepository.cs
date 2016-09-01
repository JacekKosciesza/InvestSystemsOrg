using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Shared.State.EntityFramework.Repositories;
using InvSys.Watchlists.Core.Models;
using InvSys.Watchlists.Core.State;
using Microsoft.EntityFrameworkCore;

namespace InvSys.Watchlists.State.EntityFramework.Repositories
{
    public class WatchlistsRepository : BaseRepository<Watchlist, Guid>, IWatchlistsRepository
    {
        private readonly WatchlistsContext _watchlistsContext;
        public WatchlistsRepository(WatchlistsContext dbContext)
            : base(dbContext)
        {
            _watchlistsContext = dbContext;
        }

        public override Task<Watchlist> Get(Guid id)
        {
            return _watchlistsContext.Watchlists.Include(c => c.Translations).Include(c => c.Items).SingleOrDefaultAsync(c => c.Id == id);
        }

        public override Task<List<Watchlist>> GetAll()
        {
            return _watchlistsContext.Watchlists.Include(c => c.Translations).Include(c => c.Items).ToListAsync();
        }

        public override void Update(Watchlist watchlist)
        {
            var translation = watchlist.Translations.First();
            translation.Watchlist = watchlist;
            translation.WatchlistId = watchlist.Id;
            _watchlistsContext.Entry(translation).State = EntityState.Modified;

            _watchlistsContext.Watchlists.Attach(watchlist);
            _watchlistsContext.Entry(watchlist).State = EntityState.Modified;
        }
    }
}
