using System;
using System.Collections.Generic;
using InvSys.Companies.Core.Models;

namespace InvSys.Companies.Tests.Shared.Builders.Core
{
    public class CompanyBuilder
    {
        private Company _company;
        private uint _size;

        public CompanyBuilder()
        {

            _company = GenerateCompany();
        }

        private Company GenerateCompany()
        {
            return new Company
            {
                Id = Guid.NewGuid(),
                Name = $"Name [{Guid.NewGuid()}]",
                Symbol = $"Symbol-[{Guid.NewGuid()}]",
                //Description = $"Description [{Guid.NewGuid()}]",
                //Culture = "en-US"
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

        public CompanyBuilder CreateListOfSize(uint size)
        {
            _size = size;
            return this;
        }

        public Company Build()
        {
            return _company;
        }

        public ICollection<Company> BuildList()
        {
            var companies = new List<Company>();
            for (int i = 0; i < _size; i++)
            {
                companies.Add(GenerateCompany());
            }
            return companies;
        }
    }
}
