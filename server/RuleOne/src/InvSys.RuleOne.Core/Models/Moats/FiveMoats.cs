using System;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.Models.Moats
{
    public class FiveMoats : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CompanySymbol { get; set; }

        public bool Brand { get; set; }
        public bool Secret { get; set; }
        public bool Toll { get; set; }
        public bool Switching { get; set; }
        public bool Price { get; set; }
    }
}
