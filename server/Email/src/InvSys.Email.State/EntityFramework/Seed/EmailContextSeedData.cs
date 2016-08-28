using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvSys.Email.Core.Models;

namespace InvSys.Email.State.EntityFramework.Seed
{
    public class EmailContextSeedData
    {
        private readonly EmailContext _dbContext;
        public EmailContextSeedData(EmailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task EnsureSeedData()
        {
            if (!_dbContext.Templates.Any())
            {
                var template = new Template
                {
                    Id = Guid.NewGuid(),
                    Name = "Confirmation instructions",
                    Translations = new List<TemplateTranslation>
                    {
                        new TemplateTranslation
                        {
                            Culture = "en-US",
                            Description = "Email sent after account registration.",
                            Title = "Confirmation instructions",
                            Body = @"
                                Confirm Your Registration
                                <br />
                                Hello @Model.Username!
                                <br />
                                Thank you for registering for HockeyApp. Please confirm your account by clicking or tapping the button below:
                                <br />
                                <a href=""@Model.ConfirmLink"" class=""btn btn-primary"">Confirm Registration</a>
                                <br />
                                If you have any questions, please contact us at <a href=""support@investsystems.org"">support@investsystems.org</a>.
                                <br />
                                Powered by <a href=""https://investsystems.org"">InvestSystems.org</a>"
                        },
                        new TemplateTranslation
                        {
                            Culture = "pl-PL",
                            Description = "Email wysyłany po rejestracji konta.",
                            Title = "Potwierdź utworzenie konta",
                            Body = @"
                                Potwierdź swoje konto
                                <br />
                                Witaj @Model.Username!
                                <br />
                                Dziękujemy za rejestrację w InvestSystems.org. Prosimy o potwierdzenie Twojego konta poprzez kliknięcie w przycisk poniżej:
                                <br />
                                <a href=""@Model.ConfirmLink"" class=""btn btn-primary"">Potwierdź rejestrację</a>
                                <br />
                                W razie jakichkolwiek pytań, prosimy o kontakt pod <a href=""wsparcie@investsystems.org"">wsparcie@investsystems.org</a>.
                                <br />
                                Napędzany przez <a href=""https://investsystems.org"">InvestSystems.org</a>"
                        }
                    }
                };
                _dbContext.Templates.Add(template);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
