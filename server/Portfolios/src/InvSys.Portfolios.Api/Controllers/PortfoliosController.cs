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
    [Route("api/[controller]")]
    public class PortfoliosController : Controller
    {
        private readonly IPortfoliosService _portfoliosService;
        private readonly ILogger<PortfoliosController> _logger;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<PortfoliosController> _localizer;

        public PortfoliosController(IPortfoliosService portfoliosService, ILogger<PortfoliosController> logger,
            IMapper mapper, IStringLocalizer<PortfoliosController> localizer)
        {
            _portfoliosService = portfoliosService;
            _logger = logger;
            _mapper = mapper;
            _localizer = localizer;
        }

        // GET api/portfolios        
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-portfolios")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<Portfolio>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all portfolios")]
        [Produces("application/json", Type = typeof(ICollection<Portfolio>))]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting all portfolios");
            try
            {
                var portfolios = await _portfoliosService.GetPortfolios();
                return Ok(_mapper.Map<ICollection<Portfolio>>(portfolios));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all portfolios"]}", ex);
                return BadRequest();
            }
        }

        // GET api/portfolios/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [SwaggerOperation("get-portfolio")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Portfolio))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Portfolio not found")]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get portfolio")]
        [Produces("application/json", Type = typeof(Portfolio))]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation($"Getting portfolio by Id = {id}");
            try
            {
                var portfolio = await _portfoliosService.GetPortfolio(id);
                if (portfolio != null)
                {
                    return Ok(_mapper.Map<Portfolio>(portfolio));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get portfolio with Id = {id}", ex);
                return BadRequest();
            }
        }

        // POST api/portfolios
        [HttpPost]
        [SwaggerOperation("create-portfolio")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.Created, Type = typeof(Portfolio))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Portfolio))]
        public async Task<IActionResult> Post([FromBody] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                var createdPortfolio = await _portfoliosService.AddPortfolio(_mapper.Map<Core.Models.Portfolio>(portfolio));
                if (createdPortfolio != null)
                {
                    var location = $"api/portfolios/{createdPortfolio.Id}";
                    _logger.LogDebug($"Portfolio created: {location}");
                    return Created(location, _mapper.Map<Portfolio>(createdPortfolio));
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

        // PUT api/portfolios/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpPut("{id:guid}")]
        [SwaggerOperation("update-portfolio")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Portfolio))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Portfolio))]
        public async Task<IActionResult> Put(Guid id, [FromBody] Portfolio portfolio)
        {
            if (portfolio.Id != id)
            {
                return BadRequest("Invalid portfolio id");
            }

            if (ModelState.IsValid)
            {
                var updatedPortfolio = await _portfoliosService.UpdatePortfolio(_mapper.Map<Core.Models.Portfolio>(portfolio));
                if (updatedPortfolio != null)
                {
                    _logger.LogDebug($"Portfolio updated: {updatedPortfolio.Id}");
                    return Ok(_mapper.Map<Portfolio>(updatedPortfolio));
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

        // DELETE api/portfolios/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpDelete("{id:guid}")]
        [SwaggerOperation("delete-portfolio")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Portfolio not found")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _portfoliosService.DeletePortfolio(id))
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
