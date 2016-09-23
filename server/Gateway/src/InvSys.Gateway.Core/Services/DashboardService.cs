using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.Companies.Api.Client.Proxy;
using InvSys.Gateway.Core.Models;
using InvSys.RuleOne.Api.Client.Proxy;
using InvSys.Shared.Core.Model;

namespace InvSys.Gateway.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ICompaniesAPI _companiesApi;
        private readonly IRuleOneAPI _ruleOneApi;
        private readonly IMapper _mapper;


        public DashboardService(ICompaniesAPI companiesApi, IRuleOneAPI ruleOneApi, IMapper mapper)
        {            
            _companiesApi = companiesApi;
            _ruleOneApi = ruleOneApi;
            _mapper = mapper;
        }

        public async Task<Page<CompanySummary>> GetCompanies(Query query)
        {
            // get companies
            var pageOfCompanies = await _companiesApi.GetCompaniesAsync(query.Page, query.Display, query.OrderBy, query.Q);
            var pageOfDashboardCompanies = _mapper.Map<Page<CompanySummary>>(pageOfCompanies);

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

        public async Task<CompanyDetails> GetCompany(string symbol)
        {
            var getCompanyAsync = _companiesApi.GetCompanyAsync(symbol);
            var getRatingAsync = _ruleOneApi.GetRatingsAsync(symbol);

            await Task.WhenAll(getCompanyAsync, getRatingAsync);

            var company = _mapper.Map<CompanyDetails>(getCompanyAsync.Result);
            var rating = getRatingAsync.Result.FirstOrDefault();

            company.IsWonderful = rating?.IsWonderful;

            return company;
        }
    }
}
