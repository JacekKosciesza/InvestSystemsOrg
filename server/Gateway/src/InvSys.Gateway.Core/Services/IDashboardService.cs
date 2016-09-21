using System.Threading.Tasks;
using InvSys.Gateway.Core.Models;
using InvSys.Shared.Core.Model;

namespace InvSys.Gateway.Core.Services
{
    public interface IDashboardService
    {
        Task<Page<DashboardCompany>> GetCompanies(Query query);
    }
}
