using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using InvSys.Companies.Core.Models;
using InvSys.Shared.Core.Model;

namespace InvSys.Companies.Core.Services
{
    public interface ICompaniesService
    {
        Task<ICollection<Company>> GetCompanies();
        Task<Page<Company>> GetPageOfCompanies(Query query);
        Task<Company> GetCompany(Guid id);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<bool> DeleteCompany(Guid id);
    }
}
