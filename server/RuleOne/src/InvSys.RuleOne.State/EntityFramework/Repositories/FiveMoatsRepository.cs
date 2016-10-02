using System;
using System.Linq;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.Moats;
using InvSys.RuleOne.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InvSys.RuleOne.State.EntityFramework.Repositories
{
    public class FiveMoatsRepository : BaseRepository<FiveMoats, Guid>, IFiveMoatsRepository
    {
        private readonly RuleOneContext _db;
        public FiveMoatsRepository(RuleOneContext dbContext)
            : base(dbContext)
        {
            _db = dbContext;
        }

        public Task<FiveMoats> Get(string companySymbol)
        {
            var q = from moat in _db.FiveMoats.AsQueryable()
                where moat.CompanySymbol == companySymbol
                select moat;

            return q.SingleOrDefaultAsync();
        }
    }
}
