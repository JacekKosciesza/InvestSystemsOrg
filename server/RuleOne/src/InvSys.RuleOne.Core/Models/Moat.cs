using System;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.Models
{
    public class Moat : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CompanySymbol { get; set; }

        // Five Moats
        public bool Brand { get; set; }
        public bool Secret { get; set; }
        public bool Toll { get; set; }
        public bool Switching { get; set; }
        public bool Price { get; set; }

    }
}
