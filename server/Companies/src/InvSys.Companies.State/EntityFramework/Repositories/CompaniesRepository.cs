using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Companies.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using InvSys.Companies.Core.Models;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.Extensions;
using System.Globalization;

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
                .Include(c => c.Sector).Include(c => c.Sector.Translations)
                .Include(c => c.Subsector).Include(c => c.Subsector.Translations)
                .Include(c => c.Industry).Include(c => c.Industry.Translations)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public override Task<List<Company>> GetAll()
        {
            return _companiesContext.Companies
                .Include(c => c.Translations)
                .Include(c => c.Sector).Include(c => c.Sector.Translations)
                .Include(c => c.Subsector).Include(c => c.Subsector.Translations)
                .Include(c => c.Industry).Include(c => c.Industry.Translations)
                .ToListAsync();
        }

        public override async Task<Page<Company>> GetPage(Query query)
        {
            var culture = CultureInfo.CurrentCulture.Name;

            // all
            var q = _companiesContext.Companies.AsQueryable();

            // searcher
            if (query.Searcher != null && !string.IsNullOrWhiteSpace(query.Searcher.Query))
            {
                var searchFields = ((CompanyFields)Enum.Parse(typeof(CompanyFields), query.Searcher.SearchIn)).ToList<CompanyFields>();
                foreach (var searchField in searchFields)
                {
                    // TODO: use reflection or something?
                    switch (searchField)
                    {
                        case CompanyFields.Symbol:
                            q = q.Where(c => c.Symbol.ToLower().Contains(query.Searcher.Query.ToLower()));
                            break;
                        case CompanyFields.Name:
                            q = q.Where(c => c.Name.ToLower().Contains(query.Searcher.Query.ToLower()));
                            break;
                        case CompanyFields.Description:

                            q = q.Where(i => i.Translations.Any(t => t.Culture == culture && t.Description.ToLower().Contains(query.Searcher.Query.ToLower())));
                            break;
                    }
                }
            }

            // count
            var itemsCount = await q.CountAsync();

            // page
            var itemsPerPage = query.Filter.ItemsPerPage ?? 20;
            var itemsToSkip = (query.Filter.PageNumber - 1) * itemsPerPage;
            var page = new Page<Company> { CurrentPage = query.Filter.PageNumber, ItemsPerPage = itemsPerPage };
            page.TotalPages = (int)Math.Ceiling((double)itemsCount / page.ItemsPerPage);
            q = q.Skip(itemsToSkip).Take(itemsPerPage);

            // sorter
            var sortBy = (CompanyFields)Enum.Parse(typeof(CompanyFields), query.Sorter.SortBy);
            switch (sortBy)
            {
                case CompanyFields.Symbol:
                    if (query.Sorter.SortOrder == SortOrder.Ascending)
                    {
                        q = q.OrderBy(c => c.Symbol);
                    } else
                    {
                        q = q.OrderByDescending(c => c.Symbol);
                    }
                    break;
                case CompanyFields.Name:
                    if (query.Sorter.SortOrder == SortOrder.Ascending)
                    {
                        q = q.OrderBy(c => c.Name);
                    }
                    else
                    {
                        q = q.OrderByDescending(c => c.Name);
                    }
                    break;
            }

            page.Items = await q
                .Include(c => c.Translations)
                .Include(c => c.Sector).Include(c => c.Sector.Translations)
                .Include(c => c.Subsector).Include(c => c.Subsector.Translations)
                .Include(c => c.Industry).Include(c => c.Industry.Translations)
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
