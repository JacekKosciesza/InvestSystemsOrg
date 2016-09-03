using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Portfolios.Core.Models;
using InvSys.Portfolios.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InvSys.Portfolios.State.EntityFramework.Repositories
{
    public class PortfoliosRepository : BaseRepository<Portfolio, Guid>, IPortfoliosRepository
    {
        private readonly PortfoliosContext _portfoliosContext;

        public PortfoliosRepository(PortfoliosContext dbContext)
            : base(dbContext)
        {
            _portfoliosContext = dbContext;
        }

        public override Task<Portfolio> Get(Guid id)
        {
            return
                _portfoliosContext.Portfolios.Include(c => c.Translations)
                    .Include(c => c.Items)
                    .SingleOrDefaultAsync(c => c.Id == id);
        }

        public override Task<List<Portfolio>> GetAll()
        {
            return _portfoliosContext.Portfolios.Include(c => c.Translations).Include(c => c.Items).ToListAsync();
        }

        public override void Update(Portfolio portfolio)
        {
            var translation = portfolio.Translations.First();
            translation.Portfolio = portfolio;
            translation.PortfolioId = portfolio.Id;
            _portfoliosContext.Entry(translation).State = EntityState.Modified;

            _portfoliosContext.Portfolios.Attach(portfolio);
            _portfoliosContext.Entry(portfolio).State = EntityState.Modified;
        }
    }
}