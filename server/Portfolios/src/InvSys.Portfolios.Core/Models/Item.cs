using System;
using InvSys.Shared.Core.State;

namespace InvSys.Portfolios.Core.Models
{
    public class Item : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Portfolio Portfolio { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanySymbol { get; set; }
    }
}
