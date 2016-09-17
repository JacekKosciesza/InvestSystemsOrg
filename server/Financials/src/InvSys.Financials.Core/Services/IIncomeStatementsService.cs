using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;

namespace InvSys.Financials.Core.Services
{
    public interface IIncomeStatementsService
    {
        Task<ICollection<IncomeStatement>> GetIncomeStatements();
        Task<IncomeStatement> GetIncomeStatement(Guid id);
        Task<IncomeStatement> AddIncomeStatement(IncomeStatement incomeStatement);
        Task<IncomeStatement> UpdateIncomeStatement(IncomeStatement incomeStatement);
        Task<bool> DeleteIncomeStatement(Guid id);
    }
}
