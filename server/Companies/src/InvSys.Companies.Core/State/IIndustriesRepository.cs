using System;
using System.Threading.Tasks;
using InvSys.Companies.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.State
{
    public interface IIndustriesRepository : IBaseRepository<Industry, Guid>
    {
        Task<Industry> GetIndustryByName(string culture, string name);
    }
}
