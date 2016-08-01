using InvSys.Shared.Core.State;
using System;

namespace InvSys.Companies.Core.Model
{
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
