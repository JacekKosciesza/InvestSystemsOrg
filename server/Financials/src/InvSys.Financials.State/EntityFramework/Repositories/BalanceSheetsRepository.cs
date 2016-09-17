using System;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;

namespace InvSys.Financials.State.EntityFramework.Repositories
{
    public class BalanceSheetsRepository : BaseRepository<BalanceSheet, Guid>, IBalanceSheetsRepository
    {
        private readonly FinancialsContext _financialsContext;
        public BalanceSheetsRepository(FinancialsContext dbContext)
            : base(dbContext)
        {
            _financialsContext = dbContext;
        }
    }
}
