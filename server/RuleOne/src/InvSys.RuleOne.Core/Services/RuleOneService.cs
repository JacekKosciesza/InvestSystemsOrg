using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.RuleOne.Core.Services.ThreeTools;
using InvSys.RuleOne.Core.State;
using InvSys.Shared.Core.Model;
using InvSys.StockQuotes.Api.Client.Proxy;
using System;
using InvSys.RuleOne.Core.Models.Management;

namespace InvSys.RuleOne.Core.Services
{
    public class RuleOneService : IRuleOneService
    {
        private readonly IRatingsRepository _ratingsRepository;
        private readonly IStockQuotesAPI _stockQuotesApi;
        private readonly IEMAService _emaService;
        private readonly IMACDService _macdService;
        private readonly IStochasticService _stochasticService;
        private readonly IMoatsRepository _moatsRepository;
        private readonly ILeadersRepository _leadersRepository;

        public RuleOneService(IRatingsRepository ratingsRepository, IStockQuotesAPI stockQuotesApi, IEMAService emaService, IMACDService macdService, IStochasticService stochasticService, IMoatsRepository moatsRepository, ILeadersRepository leadersRepository)
        {
            _ratingsRepository = ratingsRepository;
            _stockQuotesApi = stockQuotesApi;
            _emaService = emaService;
            _macdService = macdService;
            _stochasticService = stochasticService;
            _moatsRepository = moatsRepository;
            _leadersRepository = leadersRepository;
        }

        public Task<List<Rating>> GetRatings()
        {
            return _ratingsRepository.GetAll();
        }

        public Task<Rating> GetRating(string companySymbol)
        {
            return _ratingsRepository.Get(companySymbol);
        }

        public Task<Page<Rating>> GetPageOfRatings(Query query)
        {
            return _ratingsRepository.GetPage(query);
        }

        public Task<List<Rating>> GetRatings(IEnumerable<string> companySymbols)
        {
            return _ratingsRepository.Get(companySymbols);
        }

        public Task<Moat> GetMoat(string companySymbol)
        {
            return _moatsRepository.Get(companySymbol);
        }

        public Task<List<Leader>> GetManagement(string companySymbol)
        {
            return _leadersRepository.Get(companySymbol);
        }

        public async Task<ICollection<EMAData>> GetEMA(string companySymbol, int? days)
        {
            const int emaDays = 10;
            int daysBack = days ?? 30;

            // get historical stock prices
            var startDate = DateTime.Now.AddDays(-(emaDays + daysBack));
            var prices = await _stockQuotesApi.GetHistoricalPricesAsync("ASX", companySymbol, startDate); // TODO: stock exchange

            // calculate 10 days EMA (Exponential Moving Average)
            var ema = _emaService.Calculate(prices, emaDays);

            return ema;
        }

        public async Task<ICollection<MACDData>> GetMACD(string companySymbol, int? days)
        {
            int daysBack = days ?? 30;

            // get historical stock prices
            var startDate = DateTime.Now.AddDays(-(26 + 9 + daysBack));
            var prices = await _stockQuotesApi.GetHistoricalPricesAsync("ASX", companySymbol, startDate); // TODO: stock exchange

            // calculate 12 days, 26 days, 9 days MACD (Moving Average Convergence Divergence)
            var macd = _macdService.Calculate(prices, 12, 26, 9);

            return macd;
        }

        public async Task<ICollection<StochasticData>> GetStochastic(string companySymbol, int? days)
        {
            int daysBack = days ?? 30;

            // get historical stock prices
            var startDate = DateTime.Now.AddDays(-(14 + daysBack));
            var prices = await _stockQuotesApi.GetHistoricalPricesAsync("ASX", companySymbol, startDate); // TODO: stock exchange

            // calculate 14 days, 5 days Stochastic Oscillator
            var stochastic = _stochasticService.Calculate(prices, 14, 5);

            return stochastic;
        }
    }
}
