using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using InvSys.Email.Core.State;
using System.Linq;
using System.Globalization;

namespace InvSys.Email.Core.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ITemplatesRepository _templatesRepository;
        private readonly ITemplateBuilder _templateBuilder;
        private readonly IConfigurationRoot _config;
        private readonly ILogger<EmailSender> _logger;


        public EmailSender(ITemplatesRepository templatesRepository, ITemplateBuilder templateBuilder, IConfigurationRoot config, ILogger<EmailSender> logger)
        {
            _templatesRepository = templatesRepository;
            _templateBuilder = templateBuilder;
            _config = config;
            _logger = logger;
        }

        // http://www.codeproject.com/Articles/1081306/How-to-Send-Emails-in-ASP-NET-Core
        public void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_config["email:from:name"], _config["email:from:address"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = message };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_config["email:smtp:host"], int.Parse(_config["email:smtp:port"]), (SecureSocketOptions)Enum.Parse(typeof(SecureSocketOptions), _config["email:smtp:secure"], true));
                    client.Authenticate(_config["email:smtp:username"], _config["email:smtp:password"]);
                    client.Send(emailMessage);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
                finally
                {
                    client.Disconnect(true);

                }
            }
        }
    }
}
