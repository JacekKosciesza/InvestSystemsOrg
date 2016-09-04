using System;
using System.Collections.Generic;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.Models
{
    public class Subsector : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Sector Sector { get; set; }
        public Guid SectorId { get; set; }
        public byte[] Timestamp { get; set; }

        public string Source { get; set; }

        public ICollection<SubsectorTranslation> Translations { get; set; }
    }

    public class SubsectorTranslation : Translation
    {
        public Subsector Subsector { get; set; }
        public Guid SubsectorId { get; set; }
        public byte[] Timestamp { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
