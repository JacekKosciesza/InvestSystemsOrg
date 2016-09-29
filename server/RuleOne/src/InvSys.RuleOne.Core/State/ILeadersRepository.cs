using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models.Management;
using InvSys.Shared.Core.State;

namespace InvSys.RuleOne.Core.State
{
    public interface ILeadersRepository : IBaseRepository<Leader, Guid>
    {
        Task<List<Leader>> Get(string companySymbol);
    }
}
