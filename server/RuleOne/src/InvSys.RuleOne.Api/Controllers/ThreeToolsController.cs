using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.ThreeTools;
using InvSys.RuleOne.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace InvSys.RuleOne.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    public class ThreeToolsController : Controller
    {
        private readonly IRuleOneService _ruleOneService;
        private readonly ILogger<RatingsController> _logger;
        private readonly IStringLocalizer<RatingsController> _localizer;

        public ThreeToolsController(IRuleOneService ruleOneService, ILogger<RatingsController> logger, IStringLocalizer<RatingsController> localizer)
        {
            _ruleOneService = ruleOneService;
            _logger = logger;
            _localizer = localizer;
        }

        // GET api/treetools/ema
        [HttpGet("{companySymbol}")]
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
                return Ok(ema);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get EMA"]}", ex);
                return BadRequest();
            }
        }

        // GET api/treetools/macd
        [HttpGet("{companySymbol}")]
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
                return Ok(macd);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get MACD"]}", ex);
                return BadRequest();
            }
        }

        // GET api/treetools/stochastic
        [HttpGet("{companySymbol}")]
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
                return Ok(stochastic);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get Stochastic"]}", ex);
                return BadRequest();
            }
        }
    }
}
