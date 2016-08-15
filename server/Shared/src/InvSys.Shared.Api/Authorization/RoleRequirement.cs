using Microsoft.AspNetCore.Authorization;

namespace InvSys.Shared.Api.Authorization
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }

        public RoleRequirement(string role)
        {
            Role = role;
        }
    }
}
