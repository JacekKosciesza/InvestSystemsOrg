using System;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.State
{
    public interface IMoatsRepository : IBaseRepository<Moat, Guid>
    {
        Task<Moat> Get(string companySymbol);
    }
}
