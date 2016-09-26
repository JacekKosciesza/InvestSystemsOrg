using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.RuleOne.Api.Models;
using InvSys.RuleOne.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace InvSys.RuleOne.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    //[Route("api/[controller]")]
    public class ThreeToolsController : Controller
    {
        private readonly IRuleOneService _ruleOneService;
        private readonly ILogger<RatingsController> _logger;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<RatingsController> _localizer;

        public ThreeToolsController(IRuleOneService ruleOneService, ILogger<RatingsController> logger, IMapper mapper, IStringLocalizer<RatingsController> localizer)
        {
            _ruleOneService = ruleOneService;
            _logger = logger;
            _mapper = mapper;
            _localizer = localizer;
        }

        // GET api/treetools/ema/EPAM
        [HttpGet("{companySymbol}")]
        [Route("api/[controller]/ema/{companySymbol}")]
        [AllowAnonymous]
        [SwaggerOperation("get-ema")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<EMAData>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get EMA")]
        [Produces("application/json", Type = typeof(ICollection<EMAData>))]
        public async Task<IActionResult> EMA(string companySymbol)
        {
            _logger.LogInformation("Getting EMA");
            try
            {
                var ema = await _ruleOneService.GetEMA(companySymbol);
                return Ok(_mapper.Map<ICollection<EMAData>>(ema));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get EMA"]}", ex);
                return BadRequest();
            }
        }

        // GET api/treetools/macd/EPAM
        [HttpGet("{companySymbol}")]
        [Route("api/[controller]/macd/{companySymbol}")]
        [AllowAnonymous]
        [SwaggerOperation("get-macd")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<MACDData>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get MACD")]
        [Produces("application/json", Type = typeof(ICollection<MACDData>))]
        public async Task<IActionResult> MACD(string companySymbol)
        {
            _logger.LogInformation("Getting MACD");
            try
            {
                var macd = await _ruleOneService.GetMACD(companySymbol);
                return Ok(_mapper.Map<ICollection<MACDData>>(macd));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get MACD"]}", ex);
                return BadRequest();
            }
        }

        // GET api/treetools/stochastic/EPAM
        [HttpGet("{companySymbol}")]
        [Route("api/[controller]/stochastic/{companySymbol}")]
        [AllowAnonymous]
        [SwaggerOperation("get-stochastic")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<StochasticData>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get Stochastic")]
        [Produces("application/json", Type = typeof(ICollection<StochasticData>))]
        public async Task<IActionResult> Stochastic(string companySymbol)
        {
            _logger.LogInformation("Getting Stochastic");
            try
            {
                var stochastic = await _ruleOneService.GetStochastic(companySymbol);
                return Ok(_mapper.Map<ICollection<StochasticData>>(stochastic));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get Stochastic"]}", ex);
                return BadRequest();
            }
        }
    }
}
