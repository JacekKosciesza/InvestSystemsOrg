using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace InvSys.Shared.Api.Authorization
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (context.User.HasClaim(claim => (claim.Type == "role" && claim.Value == requirement.Role))) {
                context.Succeed(requirement);
            }

            return Task.FromResult(0);
        }
    }
}
