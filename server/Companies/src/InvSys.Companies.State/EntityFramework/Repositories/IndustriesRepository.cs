using InvSys.Companies.Core.Models;
using InvSys.Companies.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InvSys.Companies.State.EntityFramework.Repositories
{
    public class IndustriesRepository : BaseRepository<Industry, Guid>, IIndustriesRepository
    {
        private readonly CompaniesContext _companiesContext;
        public IndustriesRepository(CompaniesContext dbContext)
            : base(dbContext)
        {
            _companiesContext = dbContext;
        }

        public async Task<Industry> GetIndustryByName(string culture, string name)
        {
            return await _companiesContext.Industries
                .Where(i => i.Translations.Any(t => t.Culture == culture && t.Name == name))
                .Include(x => x.Translations)
                .SingleOrDefaultAsync();
        }
    }
}
