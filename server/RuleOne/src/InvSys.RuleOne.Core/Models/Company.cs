using InvSys.RuleOne.Core.Moat;
using InvSys.Shared.Core.State;
using System;

namespace InvSys.RuleOne.Core.Models
{
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public BigFive BigFive { get; set; } // Moat
    }
}
