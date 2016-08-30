using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Email.Core.State;

namespace InvSys.Email.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly ITemplatesRepository _templatesRepository;
        private readonly ITemplateBuilder _templateBuilder;
        private readonly IEmailSender _emailSender;

        public EmailService(ITemplatesRepository templatesRepository, ITemplateBuilder templateBuilder, IEmailSender emailSender)
        {
            _templatesRepository = templatesRepository;
            _templateBuilder = templateBuilder;
            _emailSender = emailSender;
        }

        public async Task SendEmail(dynamic data)
        {
            var id = new Guid(data.templateId);
            var template = await _templatesRepository.Get(id);
            var translation = template.Translations.Single(t => t.Culture == CultureInfo.CurrentCulture.Name);
            var body = translation.Body;
            var title = translation.Title;
            var message = _templateBuilder.BuildDynamically(body, data);
            var to = data.to;
            _emailSender.SendEmail(to, title, message);
        }
    }
}
