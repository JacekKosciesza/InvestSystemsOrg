using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;

namespace InvSys.Financials.Core.Services
{
    public interface ICashFlowsService
    {
        Task<ICollection<CashFlow>> GetCashFlows();
        Task<CashFlow> GetCashFlow(Guid id);
        Task<CashFlow> AddCashFlow(CashFlow cashFlow);
        Task<CashFlow> UpdateCashFlow(CashFlow cashFlow);
        Task<bool> DeleteCashFlow(Guid id);
    }
}
