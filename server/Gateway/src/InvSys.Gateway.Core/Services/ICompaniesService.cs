using System.Threading.Tasks;
using InvSys.Gateway.Core.Models;
using InvSys.Shared.Core.Model;

namespace InvSys.Gateway.Core.Services
{
    public interface ICompaniesService
    {
        Task<Page<CompanySummary>> GetCompanies(Query query);
        Task<CompanyDetails> GetCompany(string symbol);
    }
}
