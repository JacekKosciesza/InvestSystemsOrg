using System;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
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

    public class MeaningController : Controller
    {
        private readonly IRuleOneService _ruleOneService;
        private readonly ILogger<MeaningController> _logger;
        //private readonly IMapper _mapper;
        private readonly IStringLocalizer<MeaningController> _localizer;

        public MeaningController(IRuleOneService ruleOneService, ILogger<MeaningController> logger, /*IMapper mapper,*/ IStringLocalizer<MeaningController> localizer)
        {
            _ruleOneService = ruleOneService;
            _logger = logger;
            //_mapper = mapper;
            _localizer = localizer;
        }

        // GET api/ratings        
        [HttpGet("{companySymbol}/{userId}")]
        [AllowAnonymous]
        [SwaggerOperation("get-meaning")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Meaning))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get meaning")]
        [Produces("application/json", Type = typeof(Meaning))]
        public async Task<IActionResult> Get(string companySymbol, Guid userId)
        {
            _logger.LogInformation("Getting meaning");
            try
            {
                var ratings = await _ruleOneService.GetMeaning(companySymbol, userId);
                return Ok(ratings);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get meaning"]}", ex);
                return BadRequest();
            }
        }
    }
}
