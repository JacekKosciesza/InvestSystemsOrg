using System;
using InvSys.Portfolios.Core.Models;
using InvSys.Portfolios.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;

namespace InvSys.Portfolios.State.EntityFramework.Repositories
{
    public class ItemsRepository : BaseRepository<Item, Guid>, IItemsRepository
    {
        private readonly PortfoliosContext _portfoliosContext;
        public ItemsRepository(PortfoliosContext dbContext)
            : base(dbContext)
        {
            _portfoliosContext = dbContext;
        }
    }
}
