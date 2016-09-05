using System;
using System.Threading.Tasks;
using InvSys.Companies.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.State
{
    public interface ISectorsRepository : IBaseRepository<Sector, Guid>
    {
        Task<Sector> GetSectorByName(string culture, string name);
    }
}
