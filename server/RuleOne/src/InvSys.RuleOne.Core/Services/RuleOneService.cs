using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.RuleOne.Core.Services.ThreeTools;
using InvSys.RuleOne.Core.State;
using InvSys.Shared.Core.Model;
using InvSys.StockQuotes.Api.Client.Proxy;
using System;
using AutoMapper;
using InvSys.Financials.Api.Client.Proxy;
using InvSys.RuleOne.Core.Models.Management;
using InvSys.RuleOne.Core.Models.Moats;
using InvSys.RuleOne.Core.Services.Moats;

namespace InvSys.RuleOne.Core.Services
{
    public class RuleOneService : IRuleOneService
    {
        private readonly IRatingsRepository _ratingsRepository;
        private readonly IStockQuotesAPI _stockQuotesApi;
        private readonly IEMAService _emaService;
        private readonly IMACDService _macdService;
        private readonly IStochasticService _stochasticService;
        private readonly IFiveMoatsRepository _fiveMoatsRepository;
        private readonly ILeadersRepository _leadersRepository;
        private readonly IMeaningsRepository _meaningsRepository;
        private readonly IFinancialsAPI _financialsApi;
        private readonly IMapper _mapper;
        private readonly IBigFiveGrowthRateService _bigFiveGrowthRateService;

        public RuleOneService(IRatingsRepository ratingsRepository, IStockQuotesAPI stockQuotesApi, IEMAService emaService, IMACDService macdService, IStochasticService stochasticService, IFiveMoatsRepository fiveMoatsRepository, ILeadersRepository leadersRepository, IMeaningsRepository meaningsRepository, IFinancialsAPI financialsApi, IMapper mapper, IBigFiveGrowthRateService bigFiveGrowthRateService)
        {
            _ratingsRepository = ratingsRepository;
            _stockQuotesApi = stockQuotesApi;
            _emaService = emaService;
            _macdService = macdService;
            _stochasticService = stochasticService;
            _fiveMoatsRepository = fiveMoatsRepository;
            _leadersRepository = leadersRepository;
            _meaningsRepository = meaningsRepository;
            _financialsApi = financialsApi;
            _mapper = mapper;
            _bigFiveGrowthRateService = bigFiveGrowthRateService;
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

        public Task<Meaning> GetMeaning(string companySymbol, Guid userId)
        {
            return _meaningsRepository.Get(companySymbol, userId);
        }

        public async Task<Moat> GetMoat(string companySymbol)
        {
            var getFiveMoats = _fiveMoatsRepository.Get(companySymbol);
            var getFinancialData = _financialsApi.GetFinancialDataAsync("GRMN" /*TODO: companySymbol*/, startYear: DateTime.Now.Year - 11);

            await Task.WhenAll(getFiveMoats, getFinancialData);

            var bigFiveGrowthRates = await _bigFiveGrowthRateService.Calculate(getFinancialData.Result, years: new[] {1, 5, 10});

            var moat = new Moat
            {
                FiveMoats = getFiveMoats.Result,
                BigFive = new BigFive
                {
                    BigFiveAnnual = _mapper.Map<ICollection<BigFiveAnnual>>(getFinancialData.Result),
                    BigFiveGrowthRates = bigFiveGrowthRates
                }
            };

            return moat;
        }

        public Task<List<Leader>> GetManagement(string companySymbol)
        {
            return _leadersRepository.Get(companySymbol);
        }

        public async Task<Margin> GetMargin(string companySymbol)
        {
            var currentQuote = await _stockQuotesApi.GetCurrentAsync(companySymbol);

            var margin = new Margin
            {
                // margin
                StickerPrice = null, // TODO: calculate it
                MarginOfSafety = null, // TODO: calculate it

                // calculations
                EPSFuture = null, // TODO: calculate it
                FutureMarketPrice = null, // TODO: calculate it

                // pre-calculated data
                EPSCurrent = currentQuote.Eps,
                EPSGrowthRate = null, // EPSGrowthRateRuleOne
                PEFutureEstimated = null, // TODO: calculate it (data)
                RateOfReturn = 0.15,
                Years = 10,

                // data
                EPSGrowthRateAnalysts = null,
                EPSGrowthRateHistorical = null,
                EPSGrowthRateRuleOne = null, //Math.Min(EPSGrowthRateAnalysts, EPSGrowthRateHistorical);
                PEFutureEstimatedDefault = null,
                PEFutureEstimatedHistorical = null,
                PEFutureEstimatedRuleOne = null //Math.Min(PEFutureEstimatedDefault, PEFutureEstimatedHistorical);
            };

            return margin;
        }

        public async Task<ICollection<EMAData>> GetEMA(string companySymbol, int? days)
        {
            const int emaDays = 10;
            int daysBack = days ?? 30;

            // get historical stock prices
            var startDate = DateTime.Now.AddDays(-(emaDays + daysBack));
            var prices = await _stockQuotesApi.GetHistoricalAsync("ASX", companySymbol, startDate); // TODO: stock exchange

            // calculate 10 days EMA (Exponential Moving Average)
            var ema = _emaService.Calculate(prices, emaDays);

            return ema;
        }

        public async Task<ICollection<MACDData>> GetMACD(string companySymbol, int? days)
        {
            int daysBack = days ?? 30;

            // get historical stock prices
            var startDate = DateTime.Now.AddDays(-(26 + 9 + daysBack));
            var prices = await _stockQuotesApi.GetHistoricalAsync("ASX", companySymbol, startDate); // TODO: stock exchange

            // calculate 12 days, 26 days, 9 days MACD (Moving Average Convergence Divergence)
            var macd = _macdService.Calculate(prices, 12, 26, 9);

            return macd;
        }

        public async Task<ICollection<StochasticData>> GetStochastic(string companySymbol, int? days)
        {
            int daysBack = days ?? 30;

            // get historical stock prices
            var startDate = DateTime.Now.AddDays(-(14 + daysBack));
            var prices = await _stockQuotesApi.GetHistoricalAsync("ASX", companySymbol, startDate); // TODO: stock exchange

            // calculate 14 days, 5 days Stochastic Oscillator
            var stochastic = _stochasticService.Calculate(prices, 14, 5);

            return stochastic;
        }
    }
}
