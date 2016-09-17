using System;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;

namespace InvSys.Financials.State.EntityFramework.Repositories
{
    public class RatioCalculationsRepository : BaseRepository<RatioCalculation, Guid>, IRatioCalculationsRepository
    {
        private readonly FinancialsContext _financialsContext;
        public RatioCalculationsRepository(FinancialsContext dbContext)
            : base(dbContext)
        {
            _financialsContext = dbContext;
        }
    }
}
