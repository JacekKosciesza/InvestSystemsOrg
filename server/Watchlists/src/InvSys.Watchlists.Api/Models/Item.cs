using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvSys.Watchlists.Api.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanySymbol { get; set; }
    }
}
