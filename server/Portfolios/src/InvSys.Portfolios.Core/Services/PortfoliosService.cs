using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Portfolios.Core.Models;
using InvSys.Portfolios.Core.State;

namespace InvSys.Portfolios.Core.Services
{
    public class PortfoliosService : IPortfoliosService
    {
        private readonly IPortfoliosRepository _portfoliosRepository;
        private readonly IItemsRepository _itemsRepository;

        public PortfoliosService(IPortfoliosRepository portfoliosRepository, IItemsRepository itemsRepository)
        {
            _portfoliosRepository = portfoliosRepository;
            _itemsRepository = itemsRepository;
        }

        public async Task<Portfolio> AddPortfolio(Portfolio company)
        {
            var addedPortfolio = _portfoliosRepository.Add(company);
            if (await _portfoliosRepository.SaveChangesAsync())
            {
                return addedPortfolio;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeletePortfolio(Guid id)
        {
            _portfoliosRepository.Delete(id);
            return await _portfoliosRepository.SaveChangesAsync();
        }

        public async Task<Item> AddItem(Guid portfolioId, Item item)
        {
            var addedItem = _itemsRepository.Add(item);
            if (await _itemsRepository.SaveChangesAsync())
            {
                return addedItem;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteItem(Guid id)
        {
            _itemsRepository.Delete(id);
            return await _itemsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<Portfolio>> GetPortfolios()
        {
            return await _portfoliosRepository.GetAll();
        }

        public async Task<Portfolio> GetPortfolio(Guid id)
        {
            return await _portfoliosRepository.Get(id);
        }

        public async Task<Portfolio> UpdatePortfolio(Portfolio company)
        {
            _portfoliosRepository.Update(company);
            if (await _portfoliosRepository.SaveChangesAsync())
            {
                return company;
            }
            else
            {
                return null;
            }
        }
    }
}
