using InvSys.Companies.Core.Models;
using InvSys.Companies.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InvSys.Companies.State.EntityFramework.Repositories
{
    public class SubsectorsRepository : BaseRepository<Subsector, Guid>, ISubsectorsRepository
    {
        private readonly CompaniesContext _companiesContext;
        public SubsectorsRepository(CompaniesContext dbContext)
            : base(dbContext)
        {
            _companiesContext = dbContext;
        }

        public async Task<Subsector> GetSubsectorByName(string culture, string name)
        {
            return await _companiesContext.Subsectors
                .Where(i => i.Translations.Any(t => t.Culture == culture && t.Name == name))
                .Include(x => x.Translations)
                .SingleOrDefaultAsync();
        }
    }
}
