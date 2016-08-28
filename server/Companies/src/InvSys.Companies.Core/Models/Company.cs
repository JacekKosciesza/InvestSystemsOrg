using System;
using System.Collections.Generic;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.Models
{
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }

        public ICollection<CompanyTranslation> Translations { get; set; }

        public byte[] Timestamp { get; set; }
    }

    public class CompanyTranslation : Translation
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string Description { get; set; }

        public byte[] Timestamp { get; set; }
    }
}
