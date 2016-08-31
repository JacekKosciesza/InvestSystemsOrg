using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Watchlists.Core.Models;

namespace InvSys.Watchlists.Core.Services
{
    public interface IWatchlistsService
    {
        Task<ICollection<Watchlist>> GetWatchlists();
        Task<Watchlist> GetWatchlist(Guid id);
        Task<Watchlist> AddWatchlist(Watchlist watchlist);
        Task<Watchlist> UpdateWatchlist(Watchlist watchlist);
        Task<bool> DeleteWatchlist(Guid id);

        Task<Item> AddItem(Guid watchlistId, Item item);
        Task<bool> DeleteItem(Guid item);
    }
}
