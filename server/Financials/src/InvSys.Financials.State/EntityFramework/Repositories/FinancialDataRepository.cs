using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InvSys.Financials.State.EntityFramework.Repositories
{
    public class FinancialDataRepository : BaseRepository<FinancialData, int>, IFinancialDataRepository
    {
        private readonly FinancialsContext _db;
        public FinancialDataRepository(FinancialsContext dbContext)
            : base(dbContext)
        {
            _db = dbContext;
        }

        public Task<List<FinancialData>> GetFinancialData(string companySymbol, int? startYear, int? endYear)
        {
            var data = from fd in _db.Data.AsQueryable()
                where fd.CompanySymbol == companySymbol
                select fd;

            if (startYear.HasValue)
            {
                data = from fd in data
                    where fd.Year >= startYear.Value
                    select fd;
            }

            if (endYear.HasValue)
            {
                data = from fd in data
                       where fd.Year >= endYear.Value
                       select fd;
            }

            return data.ToListAsync();
        }

        public Task<FinancialData> GetFinancialData(string companySymbol, int year)
        {
            return _db.Data
                .Where(fd => fd.CompanySymbol == companySymbol && fd.Year == year)
                .SingleOrDefaultAsync();
        }

        public void Delete(string companySymbol, int year)
        {
            var fd = GetFinancialData(companySymbol, year);
            if (fd != null)
            {
                Delete(fd.Id);
            }
        }
    }
}
