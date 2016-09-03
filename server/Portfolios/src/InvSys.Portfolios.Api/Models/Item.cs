using System;

namespace InvSys.Portfolios.Api.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanySymbol { get; set; }
    }
}
