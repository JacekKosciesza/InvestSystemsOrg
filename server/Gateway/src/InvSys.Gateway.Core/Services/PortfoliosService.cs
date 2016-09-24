using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Gateway.Core.Models;
using AutoMapper;
using InvSys.Companies.Api.Client.Proxy;
using InvSys.RuleOne.Api.Client.Proxy;
using System.Linq;
using InvSys.Portfolios.Api.Client.Proxy;

namespace InvSys.Gateway.Core.Services
{
    public class PortfoliosService : IPortfoliosService
    {
        private readonly IPortfoliosAPI _portfoliosApi;
        private readonly ICompaniesAPI _companiesApi;
        private readonly IRuleOneAPI _ruleOneApi;
        private readonly IMapper _mapper;

        public PortfoliosService(IPortfoliosAPI portfoliosApi, ICompaniesAPI companiesApi, IRuleOneAPI ruleOneApi, IMapper mapper)
        {
            _portfoliosApi = portfoliosApi;
            _companiesApi = companiesApi;
            _ruleOneApi = ruleOneApi;
            _mapper = mapper;
        }

        public async Task<ICollection<CompanySummary>> GetPortfolio(Guid userId)
        {
            // get portfolio
            var userWatchlist = await _portfoliosApi.GetPortfolioAsync(userId);
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
