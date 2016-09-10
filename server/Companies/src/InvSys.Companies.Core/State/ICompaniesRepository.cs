using System;
using InvSys.Companies.Core.Models;
using InvSys.Shared.Core.State;
using System.Threading.Tasks;
using InvSys.Shared.Core.Model;

namespace InvSys.Companies.Core.State
{
    public interface ICompaniesRepository : IBaseRepository<Company, Guid>
    {
        Task<Page<Company>> GetPage(Query query);
    }
}
