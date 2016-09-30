using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.Management;
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

    public class ManagementController : Controller
    {
        private readonly IRuleOneService _ruleOneService;
        private readonly ILogger<ManagementController> _logger;
        //private readonly IMapper _mapper;
        private readonly IStringLocalizer<ManagementController> _localizer;

        public ManagementController(IRuleOneService ruleOneService, ILogger<ManagementController> logger, /*IMapper mapper,*/ IStringLocalizer<ManagementController> localizer)
        {
            _ruleOneService = ruleOneService;
            _logger = logger;
            //_mapper = mapper;
            _localizer = localizer;
        }

        // GET api/ratings        
        [HttpGet("{companySymbol}")]
        [AllowAnonymous]
        [SwaggerOperation("get-management")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<Leader>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get management")]
        [Produces("application/json", Type = typeof(ICollection<Leader>))]
        public async Task<IActionResult> Get(string companySymbol)
        {
            _logger.LogInformation("Getting management");
            try
            {
                var leaders = await _ruleOneService.GetManagement(companySymbol);
                return Ok(leaders);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get management"]}", ex);
                return BadRequest();
            }
        }
    }
}
