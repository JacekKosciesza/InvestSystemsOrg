using InvSys.Identity.Core.Models;
using InvSys.Identity.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvSys.Identity.Api.Controllers
{
    [Route("api/[controller]")]

    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly ILogger<UsersController> _logger;
        private readonly IStringLocalizer<UsersController> _localizer;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger, IStringLocalizer<UsersController> localizer)
        {
            _usersService = usersService;
            _logger = logger;
            _localizer = localizer;
        }

        // GET api/companies
        [HttpGet]
        [SwaggerOperation("get-users")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ICollection<User>))]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest, Description = "Failed to get all users")]
        [Produces("application/json", Type = typeof(ICollection<User>))]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting all users");
            try
            {
                var companies = await _usersService.GetUsers();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_localizer["Failed to get all users"]}", ex);
                return BadRequest();
            }
        }
    }
}
