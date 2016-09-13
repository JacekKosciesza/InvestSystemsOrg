using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Companies.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using InvSys.Companies.Core.Models;
using InvSys.Shared.Core.Model;

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
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public override Task<List<Company>> GetAll()
        {
            return _companiesContext.Companies
                .Include(c => c.Translations)
                .ToListAsync();
        }

        public async Task<Page<Company>> GetPage(Query query)
        {
            // all
            var q = _companiesContext.Companies.AsQueryable();

            // search
            if (!string.IsNullOrWhiteSpace(query.Q))
            {
                q = from company in q
                    where
                        company.Symbol.ToLower().Contains(query.Q.ToLower()) ||
                        company.Name.ToLower().Contains(query.Q.ToLower())
                    select company;
            }

            


            // order
            bool asc = true;
            string prop = "Name";
            if (!string.IsNullOrWhiteSpace(query.OrderBy))
            {
                var orderBy = query.OrderBy.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (orderBy.Count() == 1)
                {
                    prop = orderBy.First();
                }
                else if (orderBy.Last().ToLower().Contains("desc"))
                {
                    asc = false;
                }
            }
            switch (prop)
            {
                case "Symbol":
                    q = asc ? q.OrderBy(c => c.Symbol) : q.OrderByDescending(c => c.Symbol);
                    break;
                default:
                    q = asc ? q.OrderBy(c => c.Name) : q.OrderByDescending(c => c.Name);
                    break;
            }

            // count
            var itemsCount = await q.CountAsync();

            // page
            
            var itemsPerPage = query.Display ?? 20;
            var itemsToSkip = (query.Page - 1) * itemsPerPage;
            var page = new Page<Company> { CurrentPage = query.Page, ItemsPerPage = itemsPerPage };
            page.TotalPages = (int)Math.Ceiling((double)itemsCount / page.ItemsPerPage);
            page.TotalItemsCount = itemsCount;
            q = q.Skip(itemsToSkip).Take(itemsPerPage);
            page.ItemsCount = await q.CountAsync();

            page.Items = await q
                .Include(c => c.Translations)
                .ToListAsync();

            return page;
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
