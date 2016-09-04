using System;
using System.Collections.Generic;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.Models
{
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public byte[] Timestamp { get; set; }

        public string Exchange { get; set; }  
        public string Symbol { get; set; } // Ticker
        public string Name { get; set; }
        public Logo Logo { get; set;}
        public string Phone { get; set; }
        public string Email { get; set; }

        public Industry Industry { get; set; }
        public Sector Sector { get; set; }
        public Subsector Subsector { get; set; }

        public ICollection<CompanyTranslation> Translations { get; set; }
    }

    public class CompanyTranslation : Translation
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public byte[] Timestamp { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
    }
}
