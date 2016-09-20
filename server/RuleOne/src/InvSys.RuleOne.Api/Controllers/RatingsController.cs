using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Services;
using InvSys.Shared.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;

namespace InvSys.RuleOne.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    [Route("api/[controller]")]

    public class RatingsController : Controller
    {
        private readonly IRuleOneService _ruleOneService;
        private readonly ILogger<RatingsController> _logger;
        //private readonly IMapper _mapper;
        private readonly IStringLocalizer<RatingsController> _localizer;

        public RatingsController(IRuleOneService ruleOneService, ILogger<RatingsController> logger, /*IMapper mapper,*/ IStringLocalizer<RatingsController> localizer)
        {
            _ruleOneService = ruleOneService;
            _logger = logger;
            //_mapper = mapper;
            _localizer = localizer;
        }

        // GET api/ratings        
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        [SwaggerOperation("get-all-ratings")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<Rating>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all ratings")]
        [Produces("application/json", Type = typeof(ICollection<Rating>))]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Getting all ratings");
            try
            {
                var ratings = await _ruleOneService.GetRatings();
                return Ok(ratings);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all ratings"]}", ex);
                return BadRequest();
            }
        }

        // GET api/ratings        
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-ratings")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Page<Rating>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get companies")]
        [Produces("application/json", Type = typeof(Page<Rating>))]
        public async Task<IActionResult> Get([FromQuery] Query query = null)
        {
            _logger.LogInformation("Getting ratings");
            try
            {
                var pageOfRatings = await _ruleOneService.GetPageOfRatings(query);
                return Ok(pageOfRatings);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get ratings"]}" + ex);
                return BadRequest();
            }
        }

        // GET api/ratings/MENT
        [HttpGet("{companySymbol}")]
        [AllowAnonymous]
        [SwaggerOperation("get-rating")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Rating))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Rating not found")]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get rating")]
        [Produces("application/json", Type = typeof(Rating))]
        public async Task<IActionResult> Get(string companySymbol)
        {
            _logger.LogInformation($"Getting rating from company = {companySymbol}");
            try
            {
                var rating = await _ruleOneService.GetRating(companySymbol);
                if (rating != null)
                {
                    return Ok(rating);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get rating for company = {companySymbol}", ex);
                return BadRequest();
            }
        }
    }
}
