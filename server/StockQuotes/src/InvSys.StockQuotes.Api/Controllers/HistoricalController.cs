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
    public class HistoricalController : Controller
    {
        private readonly IStockQuotesService _watchlistsService;
        private readonly ILogger<HistoricalController> _logger;
        private readonly IStringLocalizer<HistoricalController> _localizer;

        public HistoricalController(IStockQuotesService watchlistsService, ILogger<HistoricalController> logger, IStringLocalizer<HistoricalController> localizer)
        {
            _watchlistsService = watchlistsService;
            _logger = logger;
            _localizer = localizer;
        }

        // GET api/historical
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-historical")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<HistoricalQuote>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all historical")]
        [Produces("application/json", Type = typeof(ICollection<HistoricalQuote>))]
        public async Task<IActionResult> Get([FromQuery]string stockExchange, [FromQuery]string companySymbol, [FromQuery]DateTime? startDate, [FromQuery]DateTime? endDate)
        {
            _logger.LogInformation("Getting all historical");
            try
            {
                var pricesHistory = await _watchlistsService.GetHistoricalQuotes(stockExchange, companySymbol, startDate, endDate);
                return Ok(pricesHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all historical"]}", ex);
                return BadRequest();
            }
        }
    }
}
