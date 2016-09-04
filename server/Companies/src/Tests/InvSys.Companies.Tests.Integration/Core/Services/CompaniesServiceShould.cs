using AutoMapper;
using InvSys.Companies.Core.Services;
using InvSys.Companies.Core.State;
using InvSys.Companies.State.EntityFramework;
using InvSys.Companies.State.EntityFramework.Repositories;
using InvSys.Companies.State.EntityFramework.Seed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace InvSys.Companies.Tests.Integration.Core.Services
{
    public class CompaniesServiceShould
    {
        IServiceCollection serviceCollection; // https://msdn.microsoft.com/en-us/magazine/mt707534.aspx
        public IServiceProvider Services { get; set; }

        private MapperConfiguration _mapperConfiguration;

        public CompaniesServiceShould()
        {
            _mapperConfiguration = new MapperConfiguration(Companies.Api.Mapper.Configure);
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CompaniesContext>();
            services.AddTransient<CompaniesContextSeedData>();
            services.AddScoped<ICompaniesService, CompaniesService>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
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
    }
}
