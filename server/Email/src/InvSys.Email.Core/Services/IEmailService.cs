using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Email.Core.Models;

namespace InvSys.Email.Core.Services
{
    public interface IEmailService
    {
        Task<ICollection<Template>> GetTemplates();
        Task<Template> GetTemplate(Guid id);
        Task<Template> AddTemplate(Template template);
        Task<Template> UpdateTemplate(Template template);
        Task<bool> DeleteTemplate(Guid id);
    }
}
