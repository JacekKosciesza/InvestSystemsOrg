using AutoMapper;
using InvSys.Email.Api.Models;
using InvSys.Email.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvSys.Email.Api.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    public class TemplatesController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<TemplatesController> _logger;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<TemplatesController> _localizer;

        public TemplatesController(IEmailService emailService, ILogger<TemplatesController> logger, IMapper mapper, IStringLocalizer<TemplatesController> localizer)
        {
            _emailService = emailService;
            _logger = logger;
            _mapper = mapper;
            _localizer = localizer;
        }

        // GET api/templates        
        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("get-templates")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<Template>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all templates")]
        [Produces("application/json", Type = typeof(ICollection<Template>))]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting all templates");
            try
            {
                var templates = await _emailService.GetTemplates();
                return Ok(_mapper.Map<ICollection<Template>>(templates));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all templates"]}", ex);
                return BadRequest();
            }
        }

        // GET api/templates/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [SwaggerOperation("get-template")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Template))]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Template not found")]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get template")]
        [Produces("application/json", Type = typeof(Template))]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation($"Getting template by Id = {id}");
            try
            {
                var template = await _emailService.GetTemplate(id);
                if (template != null)
                {
                    return Ok(_mapper.Map<Template>(template));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get template with Id = {id}", ex);
                return BadRequest();
            }
        }

        // POST api/templates
        [HttpPost]
        [SwaggerOperation("create-template")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.Created, Type = typeof(Template))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Template))]
        public async Task<IActionResult> Post([FromBody]Template template)
        {
            if (ModelState.IsValid)
            {
                var createdTemplate = await _emailService.AddTemplate(_mapper.Map<Core.Models.Template>(template));
                if (createdTemplate != null)
                {
                    var location = $"api/templates/{createdTemplate.Id}";
                    _logger.LogDebug($"Template created: {location}");
                    return Created(location, _mapper.Map<Template>(createdTemplate));
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

        // PUT api/templates/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpPut("{id:guid}")]
        [SwaggerOperation("update-template")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Template))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        [Produces("application/json", Type = typeof(Template))]
        public async Task<IActionResult> Put(Guid id, [FromBody]Template template)
        {
            if (template.Id != id)
            {
                return BadRequest("Invalid template id");
            }

            if (ModelState.IsValid)
            {
                var updatedTemplate = await _emailService.UpdateTemplate(_mapper.Map<Core.Models.Template>(template));
                if (updatedTemplate != null)
                {
                    _logger.LogDebug($"Template updated: {updatedTemplate.Id}");
                    return Ok(_mapper.Map<Template>(updatedTemplate));
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

        // DELETE api/templates/38d05660-8ea1-4b12-a14d-10d916c07e9c
        [HttpDelete("{id:guid}")]
        [SwaggerOperation("delete-template")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent)]
        [SwaggerResponse(System.Net.HttpStatusCode.NotFound, Description = "Template not found")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _emailService.DeleteTemplate(id))
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
