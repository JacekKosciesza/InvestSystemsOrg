using InvSys.Gateway.Core.Models;
using System;
using System.Threading.Tasks;

namespace InvSys.Gateway.Core.Services
{
    public interface IWatchlistsService
    {
        Task<Watchlist> GetWatchlist(Guid userId);
    }
}
