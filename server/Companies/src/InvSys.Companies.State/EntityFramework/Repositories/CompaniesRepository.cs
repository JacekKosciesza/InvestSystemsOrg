using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Companies.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using InvSys.Companies.Core.Models;

namespace InvSys.Companies.State.EntityFramework.Repositories
{
    public class CompaniesRepository : BaseRepository<Company, Guid>, ICompaniesRepository
    {
        private readonly CompaniesContext _companiesContext;
        public CompaniesRepository(CompaniesContext dbContext)
            : base(dbContext)
        {
            _companiesContext = dbContext;
        }

        public override Task<Company> Get(Guid id)
        {
            return _companiesContext.Companies
                .Include(c => c.Translations)
                .Include(c => c.Industry).Include(c => c.Industry.Translations)
                .Include(c => c.Sector).Include(c => c.Sector.Translations)
                .Include(c => c.Subsector).Include(c => c.Subsector.Translations)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public override Task<List<Company>> GetAll()
        {
            return _companiesContext.Companies
                .Include(c => c.Translations)
                .Include(c => c.Industry).Include(c => c.Industry.Translations)
                .Include(c => c.Sector).Include(c => c.Sector.Translations)
                .Include(c => c.Subsector).Include(c => c.Subsector.Translations)
                .ToListAsync();
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
