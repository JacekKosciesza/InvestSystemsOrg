using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InvSys.Identity.Core.Models
{
    public class User : IdentityUser
    {
        public bool IsProfessionalInvestor { get; set; }
    }
}
