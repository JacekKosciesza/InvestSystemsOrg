using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Identity.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InvSys.Identity.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<User> _userManager;

        public UsersService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public Task<List<User>> GetUsers()
        {
            return _userManager.Users.ToListAsync();
        }
    }
}
