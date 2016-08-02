using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Companies.Core.Model;
using InvSys.Companies.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InvSys.Companies.State.EntityFramework.Repositories
{
    public class CompaniesRepository : BaseRepository<Company, Guid>, ICompaniesRepository
    {
        private CompaniesContext _companiesContext;
        public CompaniesRepository(CompaniesContext dbContext)
            : base(dbContext)
        {
            _companiesContext = dbContext;
        }

        public override Task<Company> Get(Guid id)
        {
            return _companiesContext.Companies.Include(c => c.Translations).SingleOrDefaultAsync(c => c.Id == id);
        }

        public override Task<List<Company>> GetAll()
        {
            return _companiesContext.Companies.Include(c => c.Translations).ToListAsync();
        }

        public override void Update(Company company)
        {
            var translation = company.Translations.First();
            translation.Company = company;
            translation.CompanyId = company.Id;
            _companiesContext.Entry(translation).State = EntityState.Modified;

            _companiesContext.Companies.Attach(company);
            _companiesContext.Entry(company).State = EntityState.Modified;
        }
    }
}
