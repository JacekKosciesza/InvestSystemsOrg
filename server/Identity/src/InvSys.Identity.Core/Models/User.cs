using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OpenIddict;

namespace InvSys.Identity.Core.Models
{
    public class User : OpenIddictUser // IdentityUser
    {
        public bool IsProfessionalInvestor { get; set; }
    }
}
