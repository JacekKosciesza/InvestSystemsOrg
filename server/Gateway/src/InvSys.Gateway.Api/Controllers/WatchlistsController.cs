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
    public class WatchlistsController : Controller
    {
        private readonly IWatchlistsService _watchlistsService;
        private readonly ILogger<CompaniesController> _logger;
        private readonly IStringLocalizer<CompaniesController> _localizer;

        public WatchlistsController(IWatchlistsService watchlistsService, ILogger<CompaniesController> logger, IStringLocalizer<CompaniesController> localizer)
        {
            _watchlistsService = watchlistsService;
            _logger = logger;
            _localizer = localizer;
        }

        // GET api/watchlists        
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-watchlist")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Watchlist))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get companies")]
        [Produces("application/json", Type = typeof(Watchlist))]
        public async Task<IActionResult> Get(Guid userId)
        {
            _logger.LogInformation($"Getting watchlist for user {userId}");
            try
            {
                var watchlist = await _watchlistsService.GetWatchlist(userId);
                return Ok(watchlist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get watchlist for user {userId}" + ex);
                return BadRequest();
            }
        }
    }
}
