using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Gateway.Core.Models;
using InvSys.Watchlists.Api.Client.Proxy;
using AutoMapper;
using InvSys.Companies.Api.Client.Proxy;
using InvSys.RuleOne.Api.Client.Proxy;
using System.Linq;

namespace InvSys.Gateway.Core.Services
{
    public class WatchlistsService : IWatchlistsService
    {
        private readonly IWatchlistsAPI _watchlistsApi;
        private readonly ICompaniesAPI _companiesApi;
        private readonly IRuleOneAPI _ruleOneApi;
        private readonly IMapper _mapper;

        public WatchlistsService(IWatchlistsAPI watchlistsApi, ICompaniesAPI companiesApi, IRuleOneAPI ruleOneApi, IMapper mapper)
        {
            _watchlistsApi = watchlistsApi;
            _companiesApi = companiesApi;
            _ruleOneApi = ruleOneApi;
            _mapper = mapper;
        }

        public async Task<ICollection<CompanySummary>> GetWatchlist(Guid userId)
        {
            // get watchlist
            var userWatchlist = await _watchlistsApi.GetWatchlistAsync(userId);
            var companySymbols = string.Join(",", userWatchlist.Items.Select(i => i.CompanySymbol));


            // get companies & rule #1 ratings
            var getCompaniesAsync = _companiesApi.GetCompaniesAsync($"[{companySymbols}]");
            var getRatingsAsync = _ruleOneApi.GetRatingsAsync(companySymbols);
            await Task.WhenAll(getCompaniesAsync, getRatingsAsync);

            var companies = _mapper.Map<ICollection<CompanySummary>>(getCompaniesAsync.Result);
            var ratings = getRatingsAsync.Result;            
            foreach (var rating in ratings)
            {
                var company = companies.SingleOrDefault(c => c.Symbol == rating.CompanySymbol);
                if (company != null)
                {
                    company.IsWonderful = rating.IsWonderful;
                }
            }

            return companies;
        }
    }
}
