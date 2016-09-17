using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;

namespace InvSys.Financials.Core.Services
{
    public interface IBalanceSheetsService
    {
        Task<ICollection<BalanceSheet>> GetBalanceSheets();
        Task<BalanceSheet> GetBalanceSheet(Guid id);
        Task<BalanceSheet> AddBalanceSheet(BalanceSheet balanceSheet);
        Task<BalanceSheet> UpdateBalanceSheet(BalanceSheet balanceSheet);
        Task<bool> DeleteBalanceSheet(Guid id);
    }
}
