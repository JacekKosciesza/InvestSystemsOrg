using System;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.State
{
    public interface IMeaningsRepository : IBaseRepository<Meaning, Guid>
    {
        Task<Meaning> Get(string companySymbol, Guid userId);
    }
}
