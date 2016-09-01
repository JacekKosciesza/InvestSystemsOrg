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
        [HttpGet]
        [Route("api/watchlists/{watchlistId:guid}/items")]        
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
                _logger.LogError($"{_localizer["Failed to get all items"]}", ex);
                return BadRequest();
            }
        }

        // POST api/watchlists/38d05660-8ea1-4b12-a14d-10d916c07e9c/items
        [HttpPost]
        [Route("api/watchlists/{watchlistId:guid}/items")]        
        [SwaggerOperation("create-item")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.Created, Type = typeof(Item))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Item))]
        public async Task<IActionResult> Post(Guid watchlistId, [FromBody] Item item)
        {
            if (ModelState.IsValid)
            {
                var mappedItem = _mapper.Map<Core.Models.Item>(item);
                mappedItem.WatchlistId = watchlistId;
                var createdItem = await _watchlistsService.AddItem(watchlistId, mappedItem);
                if (createdItem != null)
                {
                    var location = $"api/watchlists/{watchlistId}/items/{createdItem.Id}";
                    _logger.LogDebug($"Item created: {location}");
                    return Created(location, _mapper.Map<Item>(createdItem));
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

        // DELETE api/watchlists/38d05660-8ea1-4b12-a14d-10d916c07e9c/items/41d05660-8ea1-4b12-a14d-10d916c07e87
        [HttpDelete()]
        [Route("api/watchlists/{watchlistId:guid}/items/{id:guid}")]
        [SwaggerOperation("delete-item")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Item not found")]
        public async Task<IActionResult> Delete(Guid watchlistId, Guid id)
        {
            if (await _watchlistsService.DeleteItem(id))
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
