using System;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.Models
{
    public class Meaning : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CompanySymbol { get; set; }
        public Guid UserId { get; set; }

        // Statement
        public bool Whole { get; set; }
        public bool Understand { get; set; }

        // Three circles
        public bool Passion { get; set; }
        public bool Talent { get; set; }
        public bool Money { get; set; }

    }
}
