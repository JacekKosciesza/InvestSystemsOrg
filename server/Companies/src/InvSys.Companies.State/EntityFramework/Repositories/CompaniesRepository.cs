using System;
using InvSys.Companies.Core.Model;
using InvSys.Companies.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;

namespace InvSys.Companies.State.EntityFramework.Repositories
{
    public class CompaniesRepository : BaseRepository<Company, Guid>, ICompaniesRepository
    {
        public CompaniesRepository(CompaniesContext dbContext)
            : base(dbContext)
        {
        }
    }
}
