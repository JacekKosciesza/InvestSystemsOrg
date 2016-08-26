using InvSys.Gateway.Api.Models;
using InvSys.Gateway.Core.GraphQLTest;
using Microsoft.AspNetCore.Mvc;

namespace InvSys.Gateway.Api.Controllers
{
    [Route("gql/[controller]")]
    public class StarWarsController : Controller
    {
        private readonly IStarWarsGraphQL _starWarsSchema;

        public StarWarsController(IStarWarsGraphQL starWarsSchema)
        {
            _starWarsSchema = starWarsSchema;
        }


        [HttpPost]
        public JsonResult Post([FromBody] GraphQLQuery query)
        {
            return Json(
                new
                {
                    data = _starWarsSchema.Execute(query.Query)
                }
            );
        }
    }
}
