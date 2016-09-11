using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using InvSys.Companies.Core.Services;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using InvSys.Companies.Api.Models;
using InvSys.Shared.Core.Model;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;

namespace InvSys.Companies.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _companiesService;
        private readonly ILogger<CompaniesController> _logger;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CompaniesController> _localizer;

        public CompaniesController(ICompaniesService companiesService, ILogger<CompaniesController> logger, IMapper mapper, IStringLocalizer<CompaniesController> localizer)
        {
            _companiesService = companiesService;
            _logger = logger;
            _mapper = mapper;
            _localizer = localizer;
        }

        // GET api/companies        
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        [SwaggerOperation("get-all-companies")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<Company>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all companies")]
        [Produces("application/json", Type = typeof(ICollection<Company>))]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Getting all companies");
            try
            {
                var companies = await _companiesService.GetCompanies();
                return Ok(_mapper.Map<ICollection<Company>>(companies));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all companies"]}", ex);
                return BadRequest();
            }
        }

        // GET api/companies        
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-companies")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Page<Company>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get companies")]
        [Produces("application/json", Type = typeof(Page<Company>))]
        public async Task<IActionResult> Get([FromQuery] Query query = null)
        {
            _logger.LogInformation("Getting companies");
            try
            {
                var pageOfCompanies = await _companiesService.GetPageOfCompanies(query);
                return Ok(_mapper.Map<Page<Company>>(pageOfCompanies));
            } catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get companies"]}" + ex);
                return BadRequest();
            }
        }

        // GET api/companies/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [SwaggerOperation("get-company")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Company))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Company not found")]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get company")]
        [Produces("application/json", Type = typeof(Company))]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation($"Getting company by Id = {id}");
            try
            {
                var company = await _companiesService.GetCompany(id);
                if (company != null)
                {
                    return Ok(_mapper.Map<Company>(company));
                } else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get company with Id = {id}", ex);
                return BadRequest();
            }
        }

        // POST api/companies
        [HttpPost]
        [SwaggerOperation("create-company")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.Created, Type = typeof(Company))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Company))]
        public async Task<IActionResult> Post([FromBody]Company company)
        {
            if (ModelState.IsValid)
            {
                var createdCompany = await _companiesService.AddCompany(_mapper.Map<Core.Models.Company>(company));
                if (createdCompany != null)
                {
                    var location = $"api/companies/{createdCompany.Id}";
                    _logger.LogDebug($"Company created: {location}");
                    return Created(location, _mapper.Map<Company>(createdCompany));
                } else
                {
                    return BadRequest("Failed to save state");
                }
                
            } else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/companies/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpPut("{id:guid}")]
        [SwaggerOperation("update-company")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Company))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Company))]
        public async Task<IActionResult> Put(Guid id, [FromBody]Company company)
        {
            if (company.Id != id)
            {
                return BadRequest("Invalid company id");
            }

            if (ModelState.IsValid)
            {
                var updatedCompany = await _companiesService.UpdateCompany(_mapper.Map<Core.Models.Company>(company));
                if (updatedCompany != null)
                {
                    _logger.LogDebug($"Company updated: {updatedCompany.Id}");
                    return Ok(_mapper.Map<Company>(updatedCompany));
                } else
                {
                    return BadRequest("Failed to save state");
                }
            } else
            {
                return BadRequest(ModelState);

            }

        }

        // DELETE api/companies/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpDelete("{id:guid}")]
        [SwaggerOperation("delete-company")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Company not found")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _companiesService.DeleteCompany(id))
            {
                return NoContent();
            } else
            {
                return NotFound();
            }
        }
    }
}
