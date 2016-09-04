using System;
using System.Collections.Generic;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.Models
{
    public class Sector : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Industry Industry { get; set; }
        public Guid IndustryId { get; set; }
        public byte[] Timestamp { get; set; }

        public string Source { get; set; }

        public ICollection<SectorTranslation> Translations { get; set; }
        public ICollection<Subsector> Subsectors { get; set; }
    }

    public class SectorTranslation : Translation
    {
        public Sector Sector { get; set; }
        public Guid SectorId { get; set; }
        public byte[] Timestamp { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
