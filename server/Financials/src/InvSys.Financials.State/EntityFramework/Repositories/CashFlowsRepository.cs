using System;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;

namespace InvSys.Financials.State.EntityFramework.Repositories
{
    public class CashFlowsRepository : BaseRepository<CashFlow, Guid>, ICashFlowsRepository
    {
        private readonly FinancialsContext _financialsContext;
        public CashFlowsRepository(FinancialsContext dbContext)
            : base(dbContext)
        {
            _financialsContext = dbContext;
        }
    }
}
