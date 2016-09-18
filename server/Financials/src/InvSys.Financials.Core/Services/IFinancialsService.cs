using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;

namespace InvSys.Financials.Core.Services
{
    public interface IFinancialsService
    {
        Task<ICollection<FinancialData>> GetFinancialData(string companySymbol, int? year, int? startYear, int? endYear);
        Task<FinancialData> GetFinancialData(int id);
        Task<FinancialData> GetFinancialData(string companySymbol, int year);
        Task<FinancialData> AddFinancialData(FinancialData financialData);
        Task<FinancialData> UpdateFinancialData(FinancialData financialData);
        Task<bool> DeleteFinancialData(int id);
        Task<bool> DeleteFinancialData(string companySymbol, int year);
    }
}
