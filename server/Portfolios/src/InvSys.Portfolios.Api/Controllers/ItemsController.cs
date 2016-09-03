using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.Portfolios.Api.Models;
using InvSys.Portfolios.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace InvSys.Portfolios.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    public class ItemsController : Controller
    {
        private readonly IPortfoliosService _portfoliosService;
        private readonly ILogger<PortfoliosController> _logger;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<PortfoliosController> _localizer;

        public ItemsController(IPortfoliosService portfoliosService, ILogger<PortfoliosController> logger,
            IMapper mapper, IStringLocalizer<PortfoliosController> localizer)
        {
            _portfoliosService = portfoliosService;
            _logger = logger;
            _mapper = mapper;
            _localizer = localizer;
        }

        // GET api/portfolios/38d05660-8ea1-4b12-a14d-10d916c07e9c/items
        [HttpGet]
        [Route("api/portfolios/{portfolioId:guid}/items")]
        [AllowAnonymous]
        [SwaggerOperation("get-items")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<Item>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all items")]
        [Produces("application/json", Type = typeof(ICollection<Item>))]
        public async Task<IActionResult> Get(Guid portfolioId)
        {
            _logger.LogInformation("Getting all items");
            try
            {
                var portfolios = await _portfoliosService.GetPortfolio(portfolioId);
                return Ok(_mapper.Map<ICollection<Item>>(portfolios.Items));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all items"]}", ex);
                return BadRequest();
            }
        }

        // POST api/portfolios/38d05660-8ea1-4b12-a14d-10d916c07e9c/items
        [HttpPost]
        [Route("api/portfolios/{portfolioId:guid}/items")]
        [SwaggerOperation("create-item")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.Created, Type = typeof(Item))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Item))]
        public async Task<IActionResult> Post(Guid portfolioId, [FromBody] Item item)
        {
            if (ModelState.IsValid)
            {
                var mappedItem = _mapper.Map<Core.Models.Item>(item);
                mappedItem.PortfolioId = portfolioId;
                var createdItem = await _portfoliosService.AddItem(portfolioId, mappedItem);
                if (createdItem != null)
                {
                    var location = $"api/portfolios/{portfolioId}/items/{createdItem.Id}";
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

        // DELETE api/portfolios/38d05660-8ea1-4b12-a14d-10d916c07e9c/items/41d05660-8ea1-4b12-a14d-10d916c07e87
        [HttpDelete()]
        [Route("api/portfolios/{portfolioId:guid}/items/{id:guid}")]
        [SwaggerOperation("delete-item")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Item not found")]
        public async Task<IActionResult> Delete(Guid portfolioId, Guid id)
        {
            if (await _portfoliosService.DeleteItem(id))
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
