using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.Watchlists.Api.Models;
using InvSys.Watchlists.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace InvSys.Watchlists.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    //[Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IWatchlistsService _watchlistsService;
        private readonly ILogger<WatchlistsController> _logger;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<WatchlistsController> _localizer;

        public ItemsController(IWatchlistsService watchlistsService, ILogger<WatchlistsController> logger,
            IMapper mapper, IStringLocalizer<WatchlistsController> localizer)
        {
            _watchlistsService = watchlistsService;
            _logger = logger;
            _mapper = mapper;
            _localizer = localizer;
        }

        // GET api/watchlists/38d05660-8ea1-4b12-a14d-10d916c07e9c/items       
        [Route("api/watchlists/{watchlistId:guid}/items")]
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-items")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<Item>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all items")]
        [Produces("application/json", Type = typeof(ICollection<Item>))]
        public async Task<IActionResult> Get(Guid watchlistId)
        {
            _logger.LogInformation("Getting all items");
            try
            {
                var watchlists = await _watchlistsService.GetWatchlist(watchlistId);
                return Ok(_mapper.Map<ICollection<Item>>(watchlists.Items));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all watchlists"]}", ex);
                return BadRequest();
            }
        }
    }
}
