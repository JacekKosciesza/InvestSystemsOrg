using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using InvSys.Companies.Core.Services;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using InvSys.Companies.Api.Model;

namespace InvSys.Companies.Api.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _companiesService;
        private readonly ILogger<CompaniesController> _logger;
        private readonly IMapper _mapper;
        public CompaniesController(ICompaniesService companiesService, ILogger<CompaniesController> logger, IMapper mapper)
        {
            _companiesService = companiesService;
            _logger = logger;
            _mapper = mapper;
        }

        // GET api/companies
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting all companies");
            try
            {
                var companies = await _companiesService.GetCompanies();
                return Ok(_mapper.Map<ICollection<Company>>(companies));
            } catch (Exception ex)
            {
                _logger.LogError($"Failed to get all companies", ex);
                return BadRequest();
            }
        }

        // GET api/companies/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation($"Getting company by Id = {id}");
            try
            {
                var company = await _companiesService.GetCompany(id);
                return Ok(_mapper.Map<Company>(company));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get company with Id = {id}", ex);
                return BadRequest();
            }
        }

        // POST api/companies
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Company company)
        {
            if (ModelState.IsValid)
            {
                var createdCompany = await _companiesService.AddCompany(_mapper.Map<Core.Model.Company>(company));
                if (createdCompany != null)
                {
                    var location = $"api/companies/{createdCompany.Id}";
                    _logger.LogDebug($"Company created: {location}");
                    return Created(location, createdCompany);
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
        public async Task<IActionResult> Put(Guid id, [FromBody]Company company)
        {
            if (ModelState.IsValid)
            {
                var updatedCompany = await _companiesService.UpdateCompany(_mapper.Map<Core.Model.Company>(company));
                if (updatedCompany != null)
                {
                    _logger.LogDebug($"Company updated: {updatedCompany.Id}");
                    return Ok(updatedCompany);
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
