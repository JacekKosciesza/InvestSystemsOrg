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

    public class MarginController : Controller
    {
        private readonly IRuleOneService _ruleOneService;
        private readonly ILogger<MarginController> _logger;
        //private readonly IMapper _mapper;
        private readonly IStringLocalizer<MarginController> _localizer;

        public MarginController(IRuleOneService ruleOneService, ILogger<MarginController> logger, /*IMapper mapper,*/ IStringLocalizer<MarginController> localizer)
        {
            _ruleOneService = ruleOneService;
            _logger = logger;
            //_mapper = mapper;
            _localizer = localizer;
        }

        // GET api/ratings        
        [HttpGet("{companySymbol}")]
        [AllowAnonymous]
        [SwaggerOperation("get-margin")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Margin))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get margin")]
        [Produces("application/json", Type = typeof(Margin))]
        public async Task<IActionResult> Get(string companySymbol)
        {
            _logger.LogInformation("Getting margin");
            try
            {
                var ratings = await _ruleOneService.GetMargin(companySymbol);
                return Ok(ratings);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get margin"]}", ex);
                return BadRequest();
            }
        }
    }
}
