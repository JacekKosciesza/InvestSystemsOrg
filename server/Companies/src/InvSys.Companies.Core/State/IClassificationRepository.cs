using System;
using InvSys.Companies.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.State
{
    public interface IClassificationRepository : IBaseRepository<Industry, Guid> { }
}
