using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvSys.Companies.Core.Models
{
    public class AuditEntry
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
    }
}
