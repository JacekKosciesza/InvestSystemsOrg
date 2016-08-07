using InvSys.Identity.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InvSys.Identity.State.EntityFramework.Seed
{
    public class IdentityContextSeedData
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public IdentityContextSeedData(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _roleManager.FindByNameAsync("Admin") == null)
            {
                var admin = new IdentityRole
                {
                    Name = "Admin"
                };
                await _roleManager.CreateAsync(admin);
            }

            if (await _userManager.FindByEmailAsync("jacek.kosciesza@gmail.com") == null)
            {
                
                var jkosciesza = new User
                {
                    UserName = "jkosciesza",
                    Email = "jacek.kosciesza@gmail.com",
                    IsProfessionalInvestor = false                    
                };
                
                await _userManager.CreateAsync(jkosciesza, "P@ssw0rd!");
                await _userManager.AddToRoleAsync(jkosciesza, "Admin");
            }
        }
    }
}
