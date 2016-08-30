using InvSys.Email.Core.Models;
using InvSys.Email.Core.State;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvSys.Email.Core.Services
{
    public class TemplatesManager : ITemplatesManager
    {
        private readonly ITemplatesRepository _templatesRepository;

        public TemplatesManager(ITemplatesRepository templatesRepository)
        {
            _templatesRepository = templatesRepository;
        }

        public async Task<ICollection<Template>> GetTemplates()
        {
            return await _templatesRepository.GetAll();
        }

        public async Task<Template> GetTemplate(Guid id)
        {
            return await _templatesRepository.Get(id);
        }

        public async Task<Template> AddTemplate(Template template)
        {
            var addedCompany = _templatesRepository.Add(template);
            if (await _templatesRepository.SaveChangesAsync())
            {
                return addedCompany;
            }
            else
            {
                return null;
            }
        }

        public async Task<Template> UpdateTemplate(Template template)
        {
            _templatesRepository.Update(template);
            if (await _templatesRepository.SaveChangesAsync())
            {
                return template;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteTemplate(Guid id)
        {
            _templatesRepository.Delete(id);
            return await _templatesRepository.SaveChangesAsync();
        }
    }
}
