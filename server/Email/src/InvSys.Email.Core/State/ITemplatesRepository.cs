using System;
using InvSys.Email.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.Email.Core.State
{
    public interface ITemplatesRepository : IBaseRepository<Template, Guid> { }
}
