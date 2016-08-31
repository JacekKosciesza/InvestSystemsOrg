using System;
using System.Threading.Tasks;
using InvSys.Shared.Core.State;
using InvSys.Watchlists.Core.Models;

namespace InvSys.Watchlists.Core.State
{
    public interface IWatchlistsRepository : IBaseRepository<Watchlist, Guid>
    {
        Task<Item> AddItem(Guid watchlistId, Item item);
        Task<bool> DeleteItem(Guid item);
    }
}
