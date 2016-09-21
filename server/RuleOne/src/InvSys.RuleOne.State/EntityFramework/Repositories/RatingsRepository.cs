using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.State;
using InvSys.Shared.Core.Model;
using InvSys.Shared.State.EntityFramework.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InvSys.RuleOne.State.EntityFramework.Repositories
{
    public class RatingsRepository : BaseRepository<Rating, Guid>, IRatingsRepository
    {
        private readonly RuleOneContext _db;
        public RatingsRepository(RuleOneContext dbContext)
            : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<Page<Rating>> GetPage(Query query)
        {
            // all
            var q = _db.Ratings.AsQueryable();

            // order
            q = q.OrderBy(c => c.CompanySymbol);

            // count
            var itemsCount = await q.CountAsync();

            // page
            var itemsPerPage = query.Display ?? 20;
            var itemsToSkip = (query.Page - 1) * itemsPerPage;
            var page = new Page<Rating> { CurrentPage = query.Page, ItemsPerPage = itemsPerPage };
            page.TotalPages = (int)Math.Ceiling((double)itemsCount / page.ItemsPerPage);
            page.TotalItemsCount = itemsCount;
            q = q.Skip(itemsToSkip).Take(itemsPerPage);
            page.ItemsCount = await q.CountAsync();

            page.Items = await q
                .ToListAsync();

            return page;
        }

        public Task<Rating> Get(string companySymbol)
        {
            return _db.Ratings.SingleOrDefaultAsync(r => r.CompanySymbol == companySymbol);
        }

        public Task<List<Rating>> Get(IEnumerable<string> companySymbols)
        {
            var q = from rating in _db.Ratings
                    where companySymbols.Contains(rating.CompanySymbol)
                    group rating by rating.CompanySymbol into g
                    select g.OrderByDescending(t => t.Date).FirstOrDefault();

            return q.ToListAsync();
        }
    }
}
