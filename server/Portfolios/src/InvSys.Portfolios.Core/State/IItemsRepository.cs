using System;
using InvSys.Portfolios.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.Portfolios.Core.State
{
    public interface IItemsRepository : IBaseRepository<Item, Guid> { }
}
