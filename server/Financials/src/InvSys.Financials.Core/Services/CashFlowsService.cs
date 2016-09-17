using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;

namespace InvSys.Financials.Core.Services
{
    public class CashFlowsService : ICashFlowsService
    {
        private readonly ICashFlowsRepository _cashFlowsRepository;

        public CashFlowsService(ICashFlowsRepository cashFlowsRepository)
        {
            _cashFlowsRepository = cashFlowsRepository;
        }

        public async Task<CashFlow> AddCashFlow(CashFlow company)
        {
            var addedCashFlow = _cashFlowsRepository.Add(company);
            if (await _cashFlowsRepository.SaveChangesAsync())
            {
                return addedCashFlow;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteCashFlow(Guid id)
        {
            _cashFlowsRepository.Delete(id);
            return await _cashFlowsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<CashFlow>> GetCashFlows()
        {
            return await _cashFlowsRepository.GetAll();
        }

        public async Task<CashFlow> GetCashFlow(Guid id)
        {
            return await _cashFlowsRepository.Get(id);
        }

        public async Task<CashFlow> UpdateCashFlow(CashFlow company)
        {
            _cashFlowsRepository.Update(company);
            if (await _cashFlowsRepository.SaveChangesAsync())
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
