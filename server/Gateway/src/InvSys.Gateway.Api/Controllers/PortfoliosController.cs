using System;
using System.Threading.Tasks;
using InvSys.Gateway.Core.Models;
using InvSys.Gateway.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;
using System.Collections.Generic;

namespace InvSys.Gateway.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    public class PortfoliosController : Controller
    {
        private readonly IPortfoliosService _portfoliosService;
        private readonly ILogger<CompaniesController> _logger;
        private readonly IStringLocalizer<CompaniesController> _localizer;

        public PortfoliosController(IPortfoliosService portfoliosService, ILogger<CompaniesController> logger, IStringLocalizer<CompaniesController> localizer)
        {
            _portfoliosService = portfoliosService;
            _logger = logger;
            _localizer = localizer;
        }

        // GET http://localhost:5002/api/portfolios/79A75268-CB36-4E7A-918B-FE3A76C7BB82
        [HttpGet("{userId:guid}")]
        [AllowAnonymous]
        [SwaggerOperation("get-portfolio")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<CompanySummary>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get portfolio")]
        [Produces("application/json", Type = typeof(ICollection<CompanySummary>))]
        public async Task<IActionResult> Get(Guid userId)
        {
            _logger.LogInformation($"Getting portfolio for user {userId}");
            try
            {
                var watchlist = await _portfoliosService.GetPortfolio(userId);
                return Ok(watchlist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get portfolio for user {userId}" + ex);
                return BadRequest();
            }
        }
    }
}
