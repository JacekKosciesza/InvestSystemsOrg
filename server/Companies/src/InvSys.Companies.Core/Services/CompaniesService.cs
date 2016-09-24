using System;
using System.Collections.Generic;
using InvSys.Companies.Core.State;
using System.Threading.Tasks;
using InvSys.Companies.Core.Models;
using InvSys.Shared.Core.Model;
using Microsoft.Extensions.Configuration;

namespace InvSys.Companies.Core.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IConfigurationRoot _config;

        public CompaniesService(ICompaniesRepository companiesRepository, IConfigurationRoot config)
        {
            _companiesRepository = companiesRepository;
            _config = config;
        }

        public async Task<ICollection<Company>> GetCompanies()
        {
            return await _companiesRepository.GetAll();
        }

        public async Task<ICollection<Company>> GetCompanies(IEnumerable<string> companySymbols)
        {
            return await _companiesRepository.Get(companySymbols);
        }

        public async Task<Page<Company>> GetPageOfCompanies(Query query)
        {
            query.Display = query.Display ?? int.Parse(_config["ItemsPerPage"]);
            return await _companiesRepository.GetPage(query);
        }

        public async Task<Company> GetCompany(Guid id)
        {
            return await _companiesRepository.Get(id);
        }

        public async Task<Company> GetCompany(string symbol)
        {
            return await _companiesRepository.Get(symbol);
        }

        public async Task<Company> AddCompany(Company company)
        {
            var addedCompany = _companiesRepository.Add(company);
            if (await _companiesRepository.SaveChangesAsync())
            {
                return addedCompany;
            } else
            {
                return null;
            }
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _companiesRepository.Update(company);
            if (await _companiesRepository.SaveChangesAsync())
            {
                return company;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteCompany(Guid id)
        {
            _companiesRepository.Delete(id);
            return await _companiesRepository.SaveChangesAsync();
        }        
    }
}
