using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Portfolios.Core.Models;

namespace InvSys.Portfolios.Core.Services
{
    public interface IPortfoliosService
    {
        Task<ICollection<Portfolio>> GetPortfolios();
        Task<Portfolio> GetPortfolio(Guid id);
        Task<Portfolio> AddPortfolio(Portfolio portfolio);
        Task<Portfolio> UpdatePortfolio(Portfolio portfolio);
        Task<bool> DeletePortfolio(Guid id);

        Task<Item> AddItem(Guid portfolioId, Item item);
        Task<bool> DeleteItem(Guid id);
    }
}
