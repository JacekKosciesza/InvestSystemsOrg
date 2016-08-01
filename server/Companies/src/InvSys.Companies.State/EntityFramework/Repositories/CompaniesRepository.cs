using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Companies.Core.Model;
using InvSys.Companies.Core.State;
using Microsoft.EntityFrameworkCore;

namespace InvSys.Companies.State.EntityFramework.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly CompaniesContext _dbContext;

        public CompaniesRepository(CompaniesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Company Add(Company company)
        {
            _dbContext.Companies.Add(company);
            return company;
        }

        public void Delete(Guid id)
        {
            var company = new Company { Id = id };
            _dbContext.Companies.Attach(company);
            _dbContext.Companies.Remove(company);
        }

        public Task<Company> Get(Guid id)
        {
            return _dbContext.Companies.FirstAsync(c => c.Id == id);
        }

        public Task<List<Company>> GetAll()
        {
            return _dbContext.Companies.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public void Update(Company company)
        {
            _dbContext.Companies.Attach(company);
            _dbContext.Entry(company).State = EntityState.Modified;
        }
    }
}
