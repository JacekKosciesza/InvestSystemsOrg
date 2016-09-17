using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.State;

namespace InvSys.Financials.Core.Services
{
    public class RatioCalculationsService : IRatioCalculationsService
    {
        private readonly IRatioCalculationsRepository _ratioCalculationsRepository;

        public RatioCalculationsService(IRatioCalculationsRepository ratioCalculationsRepository)
        {
            _ratioCalculationsRepository = ratioCalculationsRepository;
        }

        public async Task<RatioCalculation> AddRatioCalculation(RatioCalculation ratioCalculation)
        {
            var addedRatioCalculation = _ratioCalculationsRepository.Add(ratioCalculation);
            if (await _ratioCalculationsRepository.SaveChangesAsync())
            {
                return addedRatioCalculation;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteRatioCalculation(Guid id)
        {
            _ratioCalculationsRepository.Delete(id);
            return await _ratioCalculationsRepository.SaveChangesAsync();
        }

        public async Task<ICollection<RatioCalculation>> GetRatioCalculations()
        {
            return await _ratioCalculationsRepository.GetAll();
        }

        public async Task<RatioCalculation> GetRatioCalculation(Guid id)
        {
            return await _ratioCalculationsRepository.Get(id);
        }

        public async Task<RatioCalculation> UpdateRatioCalculation(RatioCalculation ratioCalculation)
        {
            _ratioCalculationsRepository.Update(ratioCalculation);
            if (await _ratioCalculationsRepository.SaveChangesAsync())
            {
                return ratioCalculation;
            }
            else
            {
                return null;
            }
        }
    }
}
