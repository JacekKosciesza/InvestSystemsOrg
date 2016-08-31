using System;
using System.Collections.Generic;
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
    [Route("api/[controller]")]
    public class WatchlistsController : Controller
    {
        private readonly IWatchlistsService _watchlistsService;
        private readonly ILogger<WatchlistsController> _logger;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<WatchlistsController> _localizer;

        public WatchlistsController(IWatchlistsService watchlistsService, ILogger<WatchlistsController> logger,
            IMapper mapper, IStringLocalizer<WatchlistsController> localizer)
        {
            _watchlistsService = watchlistsService;
            _logger = logger;
            _mapper = mapper;
            _localizer = localizer;
        }

        // GET api/watchlists        
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-watchlists")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<Watchlist>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all watchlists")]
        [Produces("application/json", Type = typeof(ICollection<Watchlist>))]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting all watchlists");
            try
            {
                var watchlists = await _watchlistsService.GetWatchlists();
                return Ok(_mapper.Map<ICollection<Watchlist>>(watchlists));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all watchlists"]}", ex);
                return BadRequest();
            }
        }

        // GET api/watchlists/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [SwaggerOperation("get-watchlist")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Watchlist))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Watchlist not found")]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get watchlist")]
        [Produces("application/json", Type = typeof(Watchlist))]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation($"Getting watchlist by Id = {id}");
            try
            {
                var watchlist = await _watchlistsService.GetWatchlist(id);
                if (watchlist != null)
                {
                    return Ok(_mapper.Map<Watchlist>(watchlist));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get watchlist with Id = {id}", ex);
                return BadRequest();
            }
        }

        // POST api/watchlists
        [HttpPost]
        [SwaggerOperation("create-watchlist")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.Created, Type = typeof(Watchlist))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Watchlist))]
        public async Task<IActionResult> Post([FromBody] Watchlist watchlist)
        {
            if (ModelState.IsValid)
            {
                var createdWatchlist = await _watchlistsService.AddWatchlist(_mapper.Map<Core.Models.Watchlist>(watchlist));
                if (createdWatchlist != null)
                {
                    var location = $"api/watchlists/{createdWatchlist.Id}";
                    _logger.LogDebug($"Watchlist created: {location}");
                    return Created(location, _mapper.Map<Watchlist>(createdWatchlist));
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

        // PUT api/watchlists/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpPut("{id:guid}")]
        [SwaggerOperation("update-watchlist")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Watchlist))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Watchlist))]
        public async Task<IActionResult> Put(Guid id, [FromBody] Watchlist watchlist)
        {
            if (watchlist.Id != id)
            {
                return BadRequest("Invalid watchlist id");
            }

            if (ModelState.IsValid)
            {
                var updatedWatchlist = await _watchlistsService.UpdateWatchlist(_mapper.Map<Core.Models.Watchlist>(watchlist));
                if (updatedWatchlist != null)
                {
                    _logger.LogDebug($"Watchlist updated: {updatedWatchlist.Id}");
                    return Ok(_mapper.Map<Watchlist>(updatedWatchlist));
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

        // DELETE api/watchlists/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpDelete("{id:guid}")]
        [SwaggerOperation("delete-watchlist")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Watchlist not found")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _watchlistsService.DeleteWatchlist(id))
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
