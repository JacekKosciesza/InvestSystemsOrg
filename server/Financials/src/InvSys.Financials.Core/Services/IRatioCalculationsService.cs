using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Financials.Core.Models;

namespace InvSys.Financials.Core.Services
{
    public interface IRatioCalculationsService
    {
        Task<ICollection<RatioCalculation>> GetRatioCalculations();
        Task<RatioCalculation> GetRatioCalculation(Guid id);
        Task<RatioCalculation> AddRatioCalculation(RatioCalculation ratioCalculation);
        Task<RatioCalculation> UpdateRatioCalculation(RatioCalculation ratioCalculation);
        Task<bool> DeleteRatioCalculation(Guid id);
    }
}
