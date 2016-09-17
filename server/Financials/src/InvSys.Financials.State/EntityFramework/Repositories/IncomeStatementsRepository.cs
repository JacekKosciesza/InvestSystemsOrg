using System;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;

namespace InvSys.Financials.State.EntityFramework.Repositories
{
    public class IncomeStatementsRepository : BaseRepository<IncomeStatement, Guid>, IIncomeStatementsRepository
    {
        private readonly FinancialsContext _financialsContext;
        public IncomeStatementsRepository(FinancialsContext dbContext)
            : base(dbContext)
        {
            _financialsContext = dbContext;
        }
    }
}
