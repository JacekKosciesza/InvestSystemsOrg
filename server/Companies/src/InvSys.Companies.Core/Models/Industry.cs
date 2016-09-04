using System;
using System.Collections.Generic;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.Models
{
    public class Industry : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public byte[] Timestamp { get; set; }

        public string Source { get; set; }

        public ICollection<IndustryTranslation> Translations { get; set; }
        public ICollection<Sector> Sectors { get; set; }
    }

    public class IndustryTranslation : Translation
    {
        public Industry Industry { get; set; }
        public Guid IndustryId { get; set; }
        public byte[] Timestamp { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
