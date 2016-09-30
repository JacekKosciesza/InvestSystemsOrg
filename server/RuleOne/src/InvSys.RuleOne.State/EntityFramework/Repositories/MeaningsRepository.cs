using System;
using System.Linq;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InvSys.RuleOne.State.EntityFramework.Repositories
{
    public class MeaningsRepository : BaseRepository<Meaning, Guid>, IMeaningsRepository
    {
        private readonly RuleOneContext _db;
        public MeaningsRepository(RuleOneContext dbContext)
            : base(dbContext)
        {
            _db = dbContext;
        }

        public Task<Meaning> Get(string companySymbol, Guid userId)
        {
            var q = from meaning in _db.Meanings.AsQueryable()
                    where meaning.CompanySymbol == companySymbol && meaning.UserId == userId
                    select meaning;

            return q.SingleOrDefaultAsync();
        }
    }
}
