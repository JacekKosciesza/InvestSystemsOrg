using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Services;
using InvSys.Shared.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace InvSys.RuleOne.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    [Route("api/[controller]")]

    public class MoatsController : Controller
    {
        private readonly IRuleOneService _ruleOneService;
        private readonly ILogger<RatingsController> _logger;
        //private readonly IMapper _mapper;
        private readonly IStringLocalizer<RatingsController> _localizer;

        public MoatsController(IRuleOneService ruleOneService, ILogger<RatingsController> logger, /*IMapper mapper,*/ IStringLocalizer<RatingsController> localizer)
        {
            _ruleOneService = ruleOneService;
            _logger = logger;
            //_mapper = mapper;
            _localizer = localizer;
        }

        // GET api/ratings        
        [HttpGet("{companySymbol}")]
        [AllowAnonymous]
        [SwaggerOperation("get-moat")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Moat))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get moat")]
        [Produces("application/json", Type = typeof(Moat))]
        public async Task<IActionResult> Get(string companySymbol)
        {
            _logger.LogInformation("Getting moat");
            try
            {
                var ratings = await _ruleOneService.GetMoat(companySymbol);
                return Ok(ratings);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get moat"]}", ex);
                return BadRequest();
            }
        }
    }
}
