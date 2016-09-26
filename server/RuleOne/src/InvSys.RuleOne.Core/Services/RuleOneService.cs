using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.RuleOne.Core.Services.ThreeTools;
using InvSys.RuleOne.Core.State;
using InvSys.Shared.Core.Model;
using InvSys.StockQuotes.Api.Client.Proxy;

namespace InvSys.RuleOne.Core.Services
{
    public class RuleOneService : IRuleOneService
    {
        private readonly IRatingsRepository _repo;
        private readonly IStockQuotesAPI _stockQuotesApi;
        private readonly IEMAService _emaService;
        private readonly IMACDService _macdService;
        private readonly IStochasticService _stochasticService;

        public RuleOneService(IRatingsRepository repo, IStockQuotesAPI stockQuotesApi, IEMAService emaService, IMACDService macdService, IStochasticService stochasticService)
        {
            _repo = repo;
            _stockQuotesApi = stockQuotesApi;
            _emaService = emaService;
            _macdService = macdService;
            _stochasticService = stochasticService;
        }

        public Task<List<Rating>> GetRatings()
        {
            return _repo.GetAll();
        }

        public Task<Rating> GetRating(string companySymbol)
        {
            return _repo.Get(companySymbol);
        }

        public Task<Page<Rating>> GetPageOfRatings(Query query)
        {
            return _repo.GetPage(query);
        }

        public Task<List<Rating>> GetRatings(IEnumerable<string> companySymbols)
        {
            return _repo.Get(companySymbols);
        }

        public async Task<ICollection<EMAData>> GetEMA(string companySymbol)
        {
            // get historical stock prices
            var prices = await _stockQuotesApi.GetHistoricalPricesAsync("ASX", companySymbol); // TODO: stock exchange

            // calculate 10 days EMA (Exponential Moving Average)
            var ema = _emaService.Calculate(prices, 10);

            return ema;
        }

        public async Task<ICollection<MACDData>> GetMACD(string companySymbol)
        {
            // get historical stock prices
            var prices = await _stockQuotesApi.GetHistoricalPricesAsync("ASX", companySymbol); // TODO: stock exchange

            // calculate 12 days, 26 days, 9 days MACD (Moving Average Convergence Divergence)
            var macd = _macdService.Calculate(prices, 12, 26, 9);

            return macd;
        }

        public async Task<ICollection<StochasticData>> GetStochastic(string companySymbol)
        {
            // get historical stock prices
            var prices = await _stockQuotesApi.GetHistoricalPricesAsync("ASX", companySymbol); // TODO: stock exchange

            // calculate 14 days, 5 days Stochastic Oscillator
            var stochastic = _stochasticService.Calculate(prices, 14, 5);

            return stochastic;
        }


    }
}
