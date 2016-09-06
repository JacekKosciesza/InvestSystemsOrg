using AutoMapper;
using InvSys.Companies.Core.Services;
using InvSys.Companies.Core.State;
using InvSys.Companies.State.EntityFramework;
using InvSys.Companies.State.EntityFramework.Repositories;
using InvSys.Companies.State.EntityFramework.Seed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using InvSys.Companies.Core.Models;
using InvSys.Companies.Tests.Shared.Builders.Api.Client;
using Xunit;

namespace InvSys.Companies.Tests.Integration.Core.Services
{
    public class CompaniesServiceShould
    {
        IServiceCollection _serviceCollection; // https://msdn.microsoft.com/en-us/magazine/mt707534.aspx
        public IServiceProvider Services { get; set; }

        private readonly MapperConfiguration _mapperConfiguration;

        public CompaniesServiceShould()
        {
            _mapperConfiguration = new MapperConfiguration(Companies.Api.Mapper.Configure);
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // TOOD: take this configuration from Api's Startup.cs?
            services.AddDbContext<CompaniesContext>();
            services.AddTransient<CompaniesContextSeedData>();
            services.AddScoped<ICompaniesService, CompaniesService>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<ISectorsRepository, SectorsRepository>();
            services.AddScoped<ISubsectorsRepository, SubsectorsRepository>();
            services.AddScoped<IIndustriesRepository, IndustriesRepository>();
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        [Fact]
        public async void ReturnAnyCompany()
        {
            // Given
            var companiesService = Services.GetRequiredService<ICompaniesService>();

            // When
            var companies = await companiesService.GetCompanies();

            // Then
            Assert.NotNull(companies);
            Assert.NotNull(companies.Any());
        }

        [Fact]
        public async void ReturnCreatedCompany()
        {
            // Given
            var companiesService = Services.GetRequiredService<ICompaniesService>();
            var company = new Company
            {
                Id = Guid.NewGuid(),
                Name = "New company",
                Email = "new@company.com",
                Exchange = "NYSE",
                Symbol = "NEW",
                Logo = new Logo {Default = "http://urltoimage.com/path"},
                Phone = "666-123-666",
                Translations = new List<CompanyTranslation>
                {
                    new CompanyTranslation
                    {
                        Culture = "en-US",
                        Address = "Address 12/b",
                        Description = "Some description",
                        Website = "http://www.newcompany.com",
                    }
                },
                Sector = new Sector
                {
                    Translations = new List<SectorTranslation>
                    {
                        new SectorTranslation
                        {
                            Culture = "en-US",
                            Name = "Sector 1"
                        }
                    }
                },
                Subsector = new Subsector
                {
                    Translations = new List<SubsectorTranslation>
                    {
                        new SubsectorTranslation
                        {
                            Culture = "en-US",
                            Name = "Sector 1"
                        }
                    }
                },
                Industry = new Industry
                {
                    Translations = new List<IndustryTranslation>
                    {
                        new IndustryTranslation
                        {
                            Culture = "en-US",
                            Name = "Sector 1"
                        }
                    }
                }
            };

            // When            
                var createdCompany = companiesService.AddCompany(company);

            // Then
            Assert.NotNull(createdCompany);
            //Assert.Equal(createdCompany.Id, company.Id);
        }
    }
}
