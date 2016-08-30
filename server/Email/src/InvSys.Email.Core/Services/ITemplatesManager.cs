using InvSys.Email.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvSys.Email.Core.Services
{
    public interface ITemplatesManager
    {
        Task<ICollection<Template>> GetTemplates();
        Task<Template> GetTemplate(Guid id);
        Task<Template> AddTemplate(Template template);
        Task<Template> UpdateTemplate(Template template);
        Task<bool> DeleteTemplate(Guid id);
    }
}
