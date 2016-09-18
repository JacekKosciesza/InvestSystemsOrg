using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.Financials.Core.Models;
using InvSys.Financials.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace InvSys.Financials.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    //[Route("api/[controller]")]
    public class FinancialsController : Controller
    {
        private readonly IFinancialsService _financialsService;
        private readonly ILogger<FinancialsController> _logger;
        //private readonly IMapper _mapper;
        private readonly IStringLocalizer<FinancialsController> _localizer;

        public FinancialsController(IFinancialsService financialsService, ILogger<FinancialsController> logger
            /*, IMapper mapper*/, IStringLocalizer<FinancialsController> localizer)
        {
            _financialsService = financialsService;
            _logger = logger;
            //_mapper = mapper;
            _localizer = localizer;
        }

        // GET api/financials/MENT
        [Route("api/financials/{companySymbol}")]
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-financial-data")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<FinancialData>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get financial data")]
        [Produces("application/json", Type = typeof(ICollection<FinancialData>))]
        public async Task<IActionResult> Get(string companySymbol, [FromQuery]int? startYear, [FromQuery]int?endYear)
        {
            _logger.LogInformation("Getting financial data");
            try
            {
                var financialData = await _financialsService.GetFinancialData(companySymbol, startYear, endYear);
                return Ok(financialData);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to financial data"]}", ex);
                return BadRequest();
            }
        }
    }
}
