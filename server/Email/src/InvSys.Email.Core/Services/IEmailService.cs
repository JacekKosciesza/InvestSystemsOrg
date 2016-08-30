using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvSys.Email.Core.Services
{
    public interface IEmailService
    {
        Task SendEmail(dynamic data);
    }
}
