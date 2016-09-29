using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.Management;
using InvSys.RuleOne.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InvSys.RuleOne.State.EntityFramework.Repositories
{
    public class LeadersRepository : BaseRepository<Leader, Guid>, ILeadersRepository
    {
        private readonly RuleOneContext _db;
        public LeadersRepository(RuleOneContext dbContext)
            : base(dbContext)
        {
            _db = dbContext;
        }

        public Task<List<Leader>> Get(string companySymbol)
        {
            var q = from leader in _db.Leaders.AsQueryable()
                where leader.CompanySymbol == companySymbol
                select leader;

            return q.Include(l => l.LeadershipExamples).ToListAsync();
        }
    }
}
