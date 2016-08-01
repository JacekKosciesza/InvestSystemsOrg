using System.Collections.Generic;
using InvSys.Companies.Core.Model;
using System;
using System.Threading.Tasks;

namespace InvSys.Companies.Core.State
{
    public interface ICompaniesRepository
    {
        Task<List<Company>> GetAll();
        Task<Company> Get(Guid id);
        Company Add(Company company);
        void Update(Company company);
        void Delete(Guid id);
        Task<bool> SaveAsync();
    }
}
