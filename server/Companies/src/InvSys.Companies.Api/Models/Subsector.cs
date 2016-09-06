using System;
using System.Collections.Generic;

namespace InvSys.Companies.Api.Models
{
    public class Subsector
    {
        public Guid Id { get; set; }
        public string Culture { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Industry> Industries { get; set; }
    }
}
