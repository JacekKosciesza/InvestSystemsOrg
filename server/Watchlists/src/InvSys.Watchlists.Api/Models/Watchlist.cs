using System;
using System.Collections.Generic;

namespace InvSys.Watchlists.Api.Models
{
    public class Watchlist
    {
        public Guid Id { get; set; }
        public string Culture { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
