using System;
using InvSys.Shared.Core.State;
using InvSys.Watchlists.Core.Models;

namespace InvSys.Watchlists.Core.State
{
    public interface IItemsRepository : IBaseRepository<Item, Guid> { }
}
