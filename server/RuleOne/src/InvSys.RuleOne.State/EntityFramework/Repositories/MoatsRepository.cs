using System;
using System.Linq;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InvSys.RuleOne.State.EntityFramework.Repositories
{
    public class MoatsRepository : BaseRepository<Moat, Guid>, IMoatsRepository
    {
        private readonly RuleOneContext _db;
        public MoatsRepository(RuleOneContext dbContext)
            : base(dbContext)
        {
            _db = dbContext;
        }

        public Task<Moat> Get(string companySymbol)
        {
            var q = from moat in _db.Moats.AsQueryable()
                where moat.CompanySymbol == companySymbol
                select moat;

            return q.SingleOrDefaultAsync();
        }
    }
}
