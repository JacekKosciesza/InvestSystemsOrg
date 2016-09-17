using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;

namespace InvSys.Financials.Core.Services
{
    public class IncomeStatementsService : IIncomeStatementsService
    {
        private readonly IIncomeStatementsRepository _incomeStatementsRepository;

        public IncomeStatementsService(IIncomeStatementsRepository incomeStatementsRepository)
        {
            _incomeStatementsRepository = incomeStatementsRepository;
        }

        public async Task<IncomeStatement> AddIncomeStatement(IncomeStatement company)
        {
            var addedIncomeStatement = _incomeStatementsRepository.Add(company);
            if (await _incomeStatementsRepository.SaveChangesAsync())
            {
                return addedIncomeStatement;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteIncomeStatement(Guid id)
        {
            _incomeStatementsRepository.Delete(id);
            return await _incomeStatementsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<IncomeStatement>> GetIncomeStatements()
        {
            return await _incomeStatementsRepository.GetAll();
        }

        public async Task<IncomeStatement> GetIncomeStatement(Guid id)
        {
            return await _incomeStatementsRepository.Get(id);
        }

        public async Task<IncomeStatement> UpdateIncomeStatement(IncomeStatement company)
        {
            _incomeStatementsRepository.Update(company);
            if (await _incomeStatementsRepository.SaveChangesAsync())
            {
                return company;
            }
            else
            {
                return null;
            }
        }
    }
}
