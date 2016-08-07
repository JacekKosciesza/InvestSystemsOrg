using InvSys.Identity.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace InvSys.Identity.State.EntityFramework.Seed
{
    public class IdentityContextSeedData
    {
        private readonly UserManager<User> _userManager;

        public IdentityContextSeedData(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("jacek.kosciesza@gmail.com") == null)
            {
                
                var user = new User
                {
                    UserName = "jkosciesza",
                    Email = "jacek.kosciesza@gmail.com",
                    IsProfessionalInvestor = false
                };
                await _userManager.CreateAsync(user, "P@ssw0rd!");
            }
        }
    }
}
