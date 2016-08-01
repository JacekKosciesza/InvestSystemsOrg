using System;
using System.Collections.Generic;
using InvSys.Companies.Core.Model;
using InvSys.Companies.Core.State;
using System.Threading.Tasks;

namespace InvSys.Companies.Core.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CompaniesService(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<Company> AddCompany(Company company)
        {
            var addedCompany = _companiesRepository.Add(company);
            if (await _companiesRepository.SaveAsync())
            {
                return addedCompany;
            } else
            {
                return null;
            }
        }

        public async Task<bool> DeleteCompany(Guid id)
        {
            _companiesRepository.Delete(id);
            return await _companiesRepository.SaveAsync();
        }

        public async Task<ICollection<Company>> GetCompanies()
        {
            return await _companiesRepository.GetAll();
        }

        public async Task<Company> GetCompany(Guid id)
        {
            return await _companiesRepository.Get(id);
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _companiesRepository.Update(company);
            if (await _companiesRepository.SaveAsync())
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
