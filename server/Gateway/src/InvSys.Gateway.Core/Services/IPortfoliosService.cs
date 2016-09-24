using InvSys.Gateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvSys.Gateway.Core.Services
{
    public interface IPortfoliosService
    {
        Task<ICollection<CompanySummary>> GetPortfolio(Guid userId);
    }
}
