using System;
using InvSys.Shared.Core.State;

namespace InvSys.Financials.Core.Models
{
    public class FinancialData : IEntity<int>
    {
        public int Id { get; set; }

        public string CompanySymbol { get; set; }
        public int Year { get; set; }

        public string Currency { get; set; }

        // Income Statement
        public decimal? Revenue { get; set; }
        public double? EPS { get; set; } // Earnings Per Share

        // Balance Sheet
        public decimal? Equity { get; set; } // Book value or Net worth
        public decimal? Debt { get; set; }

        // Cash Flow
        public decimal? Cash { get; set; } // Free Cash Flow
        public decimal? Dividends { get; set; }

        // Ratios
        public double? ROIC { get; set; } // Return On Capital
    }
}
