using System;
using System.Collections.Generic;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.Watchlists.Core.Models
{
    public class Watchlist : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public ICollection<WatchlistTranslation> Translations { get; set; }

        public byte[] Timestamp { get; set; }
        public ICollection<Item> Items { get; set; }
    }

    public class WatchlistTranslation : Translation
    {
        public Watchlist Watchlist { get; set; }
        public Guid WatchlistId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public byte[] Timestamp { get; set; }
    }
}
