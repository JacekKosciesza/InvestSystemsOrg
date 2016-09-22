using System;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.Models
{
    public class Rating : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CompanySymbol { get; set; }
        public DateTime Date { get; set; }

        public bool IsWonderful { get; set; }
    }
}
