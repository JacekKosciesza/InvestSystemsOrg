using InvSys.Companies.Core.Model;
using System;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.State
{
    public interface ICompaniesRepository : IBaseRepository<Company, Guid> { }
}
