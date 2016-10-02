using System;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models.Moats;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.State
{
    public interface IFiveMoatsRepository : IBaseRepository<FiveMoats, Guid>
    {
        Task<FiveMoats> Get(string companySymbol);
    }
}
