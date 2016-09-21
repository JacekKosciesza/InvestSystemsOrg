using System;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.Companies.Api.Client.Proxy.Models;
using InvSys.Gateway.Core.Models;
using InvSys.Gateway.Core.Services;
using InvSys.Shared.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace InvSys.Gateway.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly ILogger<DashboardController> _logger;
        private readonly IStringLocalizer<DashboardController> _localizer;

        public DashboardController(IDashboardService dashboardService, ILogger<DashboardController> logger, IStringLocalizer<DashboardController> localizer)
        {
            _dashboardService = dashboardService;
            _logger = logger;
            _localizer = localizer;
        }

        // GET api/companies        
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-companies")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Page<DashboardCompany>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get companies")]
        [Produces("application/json", Type = typeof(Page<DashboardCompany>))]
        public async Task<IActionResult> Get([FromQuery] Query query = null)
        {
            _logger.LogInformation("Getting companies");
            try
            {
                var pageOfCompanies = await _dashboardService.GetCompanies(query);
                return Ok(pageOfCompanies);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get companies"]}" + ex);
                return BadRequest();
            }
        }
    }
}
