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
        public async Task<IActionResult> Get(string companySymbol, [FromQuery]int? year, [FromQuery]int? startYear, [FromQuery]int?endYear)
        {
            _logger.LogInformation("Getting financial data");
            try
            {
                var financialData = await _financialsService.GetFinancialData(companySymbol, year, startYear, endYear);
                return Ok(financialData);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to financial data"]}", ex);
                return BadRequest();
            }
        }

        // GET api/financials/MENT
        [HttpPost]
        [Route("api/financials/{companySymbol}")]
        [SwaggerOperation("create-financial-data")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.Created, Type = typeof(FinancialData))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(FinancialData))]
        public async Task<IActionResult> Post(FinancialData financialData)
        {
            if (ModelState.IsValid)
            {
                var createdFinancialData = await _financialsService.AddFinancialData(financialData);
                if (createdFinancialData != null)
                {
                    var location = $"api/financials/{financialData.CompanySymbol}?year={financialData.Year}";
                    _logger.LogDebug($"Financial data created: {location}");
                    return Created(location, createdFinancialData);
                }
                else
                {
                    return BadRequest("Failed to save state");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/financials/MENT?year=2015
        [Route("api/financials/{companySymbol}")]
        [HttpPut]
        [SwaggerOperation("update-financial-data")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(FinancialData))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(FinancialData))]
        public async Task<IActionResult> Put(string companySymbol, [FromQuery]int year, [FromBody]FinancialData financialData)
        {
            if (financialData.CompanySymbol != companySymbol || financialData.Year != year)
            {
                return BadRequest("Invalid financial data query");
            }

            if (ModelState.IsValid)
            {
                var updatedFinancialData = await _financialsService.UpdateFinancialData(financialData);
                if (updatedFinancialData != null)
                {
                    _logger.LogDebug($"Financial data updated: {updatedFinancialData.Id}");
                    return Ok(updatedFinancialData);
                }
                else
                {
                    return BadRequest("Failed to save state");
                }
            }
            else
            {
                return BadRequest(ModelState);

            }
        }

        // DELETE api/financials/MENT?year=2015
        [HttpDelete()]
        [Route("api/financials/{companySymbol}")]
        [SwaggerOperation("delete-financial-data")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Financial data not found")]
        public async Task<IActionResult> Delete(string companySymbol, [FromQuery]int year)
        {
            if (await _financialsService.DeleteFinancialData(companySymbol, year))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
