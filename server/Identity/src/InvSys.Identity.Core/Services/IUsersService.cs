using InvSys.Identity.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvSys.Identity.Core.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetUsers();
    }
}
