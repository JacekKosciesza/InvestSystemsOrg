using System;
using System.Collections.Generic;

namespace InvSys.Companies.Api.Models
{
    public class Industry
    {
        public Guid Id { get; set; }
        public string Culture { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Sector> Sectors { get; set; }

    }
}
