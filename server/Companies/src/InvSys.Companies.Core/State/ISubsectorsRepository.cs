using System;
using System.Threading.Tasks;
using InvSys.Companies.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.State
{
    public interface ISubsectorsRepository : IBaseRepository<Subsector, Guid>
    {
        Task<Subsector> GetSubsectorByName(string culture, string name);
    }
}
