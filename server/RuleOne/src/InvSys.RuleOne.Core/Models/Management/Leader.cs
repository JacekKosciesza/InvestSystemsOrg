using System;
using System.Collections.Generic;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.Models.Management
{
    public class Leader : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CompanySymbol { get; set; }

        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Position { get; set; }
        public bool IsLevelFiveLeader { get; set; }

        public ICollection<LeadershipExample> LeadershipExamples { get; set; }
    }
}
