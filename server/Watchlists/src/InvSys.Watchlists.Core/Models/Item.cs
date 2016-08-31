using System;
using InvSys.Shared.Core.State;

namespace InvSys.Watchlists.Core.Models
{
    public class Item : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Watchlist Watchlist { get; set; }
        public Guid WatchlistId { get; set; }
        public Guid CompanyId  { get; set; }
        public string CompanySymbol { get; set; }
    }
}
