using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.Companies.Api.Client.Proxy;
using InvSys.Gateway.Core.Models;
using InvSys.RuleOne.Api.Client.Proxy;
using InvSys.Shared.Core.Model;
using Microsoft.Extensions.Configuration;

namespace InvSys.Gateway.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ICompaniesAPI _companiesApi;
        private readonly IRuleOneAPI _ruleOneApi;
        private readonly IMapper _mapper;
        IConfigurationRoot _configuration;


        public DashboardService(/*ICompaniesAPI companiesApi, IRuleOneAPI ruleOneApi, */IMapper mapper, IConfigurationRoot configuration)
        {            
            _mapper = mapper;
            _configuration = configuration;
            _companiesApi = new CompaniesAPI(new Uri(_configuration["APIs:Companies:Url"], UriKind.Absolute));
            _ruleOneApi = new RuleOneAPI(new Uri(_configuration["APIs:RuleOne:Url"], UriKind.Absolute));
        }

        public async Task<Page<DashboardCompany>> GetCompanies(Query query)
        {
            // get companies
            var pageOfCompanies = await _companiesApi.GetCompaniesAsync(query.Page, query.Display, query.OrderBy, query.Q);
            var pageOfDashboardCompanies = _mapper.Map<Page<DashboardCompany>>(pageOfCompanies);

            // get rule #1 ratings for the companies
            var companySymbols = string.Join(",", pageOfCompanies.Items.Select(c => c.Symbol));
            if (!string.IsNullOrWhiteSpace(companySymbols))
            {
                var ratings = await _ruleOneApi.GetRatingsAsync(companySymbols);
                foreach (var rating in ratings)
                {
                    var company = pageOfDashboardCompanies.Items.SingleOrDefault(c => c.Symbol == rating.CompanySymbol);
                    if (company != null)
                    {
                        company.IsWonderful = rating.IsWonderful;
                    }
                }
            }

            return pageOfDashboardCompanies;
        }
    }
}
