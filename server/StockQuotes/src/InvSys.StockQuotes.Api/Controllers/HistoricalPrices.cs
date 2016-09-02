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
    public class HistoricalPrices : Controller
    {
        private readonly IStockQuotesService _watchlistsService;
        private readonly ILogger<HistoricalPrices> _logger;
        private readonly IStringLocalizer<HistoricalPrices> _localizer;

        public HistoricalPrices(IStockQuotesService watchlistsService, ILogger<HistoricalPrices> logger, IStringLocalizer<HistoricalPrices> localizer)
        {
            _watchlistsService = watchlistsService;
            _logger = logger;
            _localizer = localizer;
        }

        // GET api/watchlists        
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-historical-prices")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<HistoricalQuote>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all historical prices")]
        [Produces("application/json", Type = typeof(ICollection<HistoricalQuote>))]
        public async Task<IActionResult> Get(string stockExchange, string companySymbol, DateTime? startDate, DateTime? endDate)
        {
            _logger.LogInformation("Getting all historical prices");
            try
            {
                var pricesHistory = await _watchlistsService.GetHistoricalQuotes(stockExchange, companySymbol, startDate, endDate);
                return Ok(pricesHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all historical prices"]}", ex);
                return BadRequest();
            }
        }
    }
}
