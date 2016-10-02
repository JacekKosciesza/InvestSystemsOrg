using System;
using System.Threading.Tasks;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.Moats;
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

    public class MoatsController : Controller
    {
        private readonly IRuleOneService _ruleOneService;
        private readonly ILogger<MoatsController> _logger;
        //private readonly IMapper _mapper;
        private readonly IStringLocalizer<MoatsController> _localizer;

        public MoatsController(IRuleOneService ruleOneService, ILogger<MoatsController> logger, /*IMapper mapper,*/ IStringLocalizer<MoatsController> localizer)
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
