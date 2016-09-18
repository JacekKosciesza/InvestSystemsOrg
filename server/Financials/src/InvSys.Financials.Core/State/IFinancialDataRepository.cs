using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.Financials.Core.State
{
    public interface IFinancialDataRepository : IBaseRepository<FinancialData, int>
    {
        Task<List<FinancialData>> GetFinancialData(string companySymbol, int? year, int? startYear, int? endYear);
        Task<FinancialData> GetFinancialData(string companySymbol, int year);
        void Delete(string companySymbol, int year);
    }
}
