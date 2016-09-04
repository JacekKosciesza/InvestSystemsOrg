using InvSys.Companies.Core.Models;
using InvSys.Companies.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using System;

namespace InvSys.Companies.State.EntityFramework.Repositories
{
    public class ClassificationRepository : BaseRepository<Industry, Guid>, IClassificationRepository
    {
        private readonly CompaniesContext _companiesContext;
        public ClassificationRepository(CompaniesContext dbContext)
            : base(dbContext)
        {
            _companiesContext = dbContext;
        }
    }
}
