using System;
using InvSys.Shared.Core.State;

namespace InvSys.Financials.Core.Models
{
    public class RatioCalculation : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }
        public string CompanySymbol { get; set; }
        public DateTime Year { get; set; }

        public double ReturnOnCapital { get; set; } // ROIC
    }
}
