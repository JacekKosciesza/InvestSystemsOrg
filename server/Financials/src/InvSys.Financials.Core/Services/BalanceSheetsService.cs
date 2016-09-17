using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;

namespace InvSys.Financials.Core.Services
{
    public class BalanceSheetsService : IBalanceSheetsService
    {
        private readonly IBalanceSheetsRepository _balanceSheetsRepository;

        public BalanceSheetsService(IBalanceSheetsRepository balanceSheetsRepository)
        {
            _balanceSheetsRepository = balanceSheetsRepository;
        }

        public async Task<BalanceSheet> AddBalanceSheet(BalanceSheet company)
        {
            var addedBalanceSheet = _balanceSheetsRepository.Add(company);
            if (await _balanceSheetsRepository.SaveChangesAsync())
            {
                return addedBalanceSheet;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteBalanceSheet(Guid id)
        {
            _balanceSheetsRepository.Delete(id);
            return await _balanceSheetsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<BalanceSheet>> GetBalanceSheets()
        {
            return await _balanceSheetsRepository.GetAll();
        }

        public async Task<BalanceSheet> GetBalanceSheet(Guid id)
        {
            return await _balanceSheetsRepository.Get(id);
        }

        public async Task<BalanceSheet> UpdateBalanceSheet(BalanceSheet company)
        {
            _balanceSheetsRepository.Update(company);
            if (await _balanceSheetsRepository.SaveChangesAsync())
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
