using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.StockQuotes.Core.Models;
using InvSys.StockQuotes.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace InvSys.StockQuotes.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    public class CurrentController : Controller
    {
        private readonly IStockQuotesService _stockQuotesService;
        private readonly ILogger<CurrentController> _logger;
        private readonly IStringLocalizer<CurrentController> _localizer;

        public CurrentController(IStockQuotesService stockQuotesService, ILogger<CurrentController> logger, IStringLocalizer<CurrentController> localizer)
        {
            _stockQuotesService = stockQuotesService;
            _logger = logger;
            _localizer = localizer;
        }

        // GET api/current        
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-current")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(CurrentQuote))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all current")]
        [Produces("application/json", Type = typeof(CurrentQuote))]
        public async Task<IActionResult> Get([FromQuery]string companySymbol)
        {
            _logger.LogInformation("Getting all current");
            try
            {
                var pricesHistory = await _stockQuotesService.GetCurrentQuote(companySymbol);
                return Ok(pricesHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all current"]}", ex);
                return BadRequest();
            }
        }
    }
}
