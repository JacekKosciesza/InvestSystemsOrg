using AutoMapper;
using InvSys.Email.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using RazorEngine.Templating;
using Swashbuckle.SwaggerGen.Annotations;
using System.Threading.Tasks;

namespace InvSys.Email.Api.Controllers
{
    //[Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<TemplatesController> _logger;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<TemplatesController> _localizer;

        public EmailController(IEmailService emailService, ILogger<TemplatesController> logger, IMapper mapper, IStringLocalizer<TemplatesController> localizer)
        {
            _emailService = emailService;
            _logger = logger;
            _mapper = mapper;
            _localizer = localizer;
        }

        // POST api/templates
        [HttpPost]
        [SwaggerOperation("send-email")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Invalid arguments")]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody]DynamicViewBag data)
        {
            _emailService.SendEmail(data);
            
            return Ok();
        }
    }
}
