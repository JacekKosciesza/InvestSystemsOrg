using System;
using System.Collections.Generic;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.Portfolios.Core.Models
{
    public class Portfolio : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public ICollection<PortfolioTranslation> Translations { get; set; }

        public byte[] Timestamp { get; set; }
        public ICollection<Item> Items { get; set; }
    }
    public class PortfolioTranslation : Translation
    {
        public Portfolio Portfolio { get; set; }
        public Guid PortfolioId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public byte[] Timestamp { get; set; }
    }
}
