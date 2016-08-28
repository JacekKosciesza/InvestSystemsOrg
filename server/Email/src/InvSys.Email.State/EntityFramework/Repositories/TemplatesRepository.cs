using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Email.Core.Models;
using InvSys.Email.Core.State;
using InvSys.Shared.State.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InvSys.Email.State.EntityFramework.Repositories
{
    public class TemplatesRepository : BaseRepository<Template, Guid>, ITemplatesRepository
    {
        private readonly EmailContext _emailContext;

        public TemplatesRepository(EmailContext dbContext, EmailContext emailContext) : base(dbContext)
        {
            _emailContext = emailContext;
        }

        public override Task<Template> Get(Guid id)
        {
            return _emailContext.Templates.Include(c => c.Translations).SingleOrDefaultAsync(c => c.Id == id);
        }

        public override Task<List<Template>> GetAll()
        {
            return _emailContext.Templates.Include(c => c.Translations).ToListAsync();
        }

        public override void Update(Template company)
        {
            var translation = company.Translations.First();
            translation.Template = company;
            translation.TemplateId = company.Id;
            _emailContext.Entry(translation).State = EntityState.Modified;

            _emailContext.Templates.Attach(company);
            _emailContext.Entry(company).State = EntityState.Modified;
        }
    }
}
