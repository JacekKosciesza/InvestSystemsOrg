using InvSys.Companies.Tests.Integration.Proxy.Models;
using System;

namespace InvSys.Companies.Tests.Integration
{
    public class CompanyBuilder
    {
        private Company _company;

        public CompanyBuilder()
        {

            _company = new Company
            {
                Id = Guid.NewGuid(),
                Name = $"Name [{Guid.NewGuid()}]",
                Symbol = $"Symbol-[{Guid.NewGuid()}]",
                Description = $"Description [{Guid.NewGuid()}]",
                Culture = "en-US"
            };
        }

        public CompanyBuilder WithId(Guid id)
        {
            _company.Id = id;
            return this;
        }

        public CompanyBuilder WithId(string id)
        {
            return WithId(new Guid(id));
        }

        public Company Build()
        {
            return _company;
        }
    }
}
