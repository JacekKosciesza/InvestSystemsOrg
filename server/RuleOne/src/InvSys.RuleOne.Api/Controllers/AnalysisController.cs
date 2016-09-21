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

    public class AnalysisController : Controller
    {
        private readonly IRuleOneService _ruleOneService;
        private readonly ILogger<RatingsController> _logger;
        //private readonly IMapper _mapper;
        private readonly IStringLocalizer<RatingsController> _localizer;

        public AnalysisController(IRuleOneService ruleOneService, ILogger<RatingsController> logger, /*IMapper mapper,*/ IStringLocalizer<RatingsController> localizer)
        {
            _ruleOneService = ruleOneService;
            _logger = logger;
            //_mapper = mapper;
            _localizer = localizer;
        }
    }
}
