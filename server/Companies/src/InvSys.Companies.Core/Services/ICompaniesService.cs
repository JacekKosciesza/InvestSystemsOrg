using System.Collections.Generic;
using InvSys.Companies.Core.Model;
using System;
using System.Threading.Tasks;

namespace InvSys.Companies.Core.Services
{
    public interface ICompaniesService
    {
        Task<ICollection<Company>> GetCompanies();
        Task<Company> GetCompany(Guid id);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<bool> DeleteCompany(Guid id);
    }
}
