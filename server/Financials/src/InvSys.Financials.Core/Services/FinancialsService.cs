using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;

namespace InvSys.Financials.Core.Services
{
    public class FinancialsService : IFinancialsService
    {
        private readonly IFinancialDataRepository _repository;

        public FinancialsService(IFinancialDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<FinancialData>> GetFinancialData(string companySymbol, int? startYear, int? endYear)
        {
            return await _repository.GetFinancialData(companySymbol, startYear, endYear);
        }

        public async Task<FinancialData> GetFinancialData(int id)
        {
            return await _repository.Get(id);
        }

        public Task<FinancialData> GetFinancialData(string companySymbol, int year)
        {
            return _repository.GetFinancialData(companySymbol, year);
        }

        public async Task<FinancialData> AddFinancialData(FinancialData financialData)
        {
            var addedFinancialData = _repository.Add(financialData);
            if (await _repository.SaveChangesAsync())
            {
                return addedFinancialData;
            }
            else
            {
                return null;
            }
        }

        public async Task<FinancialData> UpdateFinancialData(FinancialData financialData)
        {
            _repository.Update(financialData);
            if (await _repository.SaveChangesAsync())
            {
                return financialData;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteFinancialData(int id)
        {
            _repository.Delete(id);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteFinancialData(string companySymbol, int year)
        {
            _repository.Delete(companySymbol, year);
            return await _repository.SaveChangesAsync();
        }
    }
}
