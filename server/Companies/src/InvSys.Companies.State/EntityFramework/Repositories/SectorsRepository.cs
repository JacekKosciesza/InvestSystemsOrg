using InvSys.Companies.Core.Models;
using InvSys.Companies.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InvSys.Companies.State.EntityFramework.Repositories
{
    public class SectorsRepository : BaseRepository<Sector, Guid>, ISectorsRepository
    {
        private readonly CompaniesContext _companiesContext;
        public SectorsRepository(CompaniesContext dbContext)
            : base(dbContext)
        {
            _companiesContext = dbContext;
        }

        public async Task<Sector> GetSectorByName(string culture, string name)
        {
            return await _companiesContext.Sectors
                .Where(i => i.Translations.Any(t => t.Culture == culture && t.Name == name))
                .Include(x => x.Translations)
                .SingleOrDefaultAsync();
        }
    }
}
