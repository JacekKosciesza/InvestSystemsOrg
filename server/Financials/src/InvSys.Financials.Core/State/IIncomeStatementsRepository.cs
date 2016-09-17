using System;
using InvSys.Financials.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.Financials.Core.State
{
    public interface IIncomeStatementsRepository : IBaseRepository<IncomeStatement, Guid> { }
}
