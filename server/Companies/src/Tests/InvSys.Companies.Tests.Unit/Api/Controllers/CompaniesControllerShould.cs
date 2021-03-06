﻿using AutoMapper;
using InvSys.Companies.Api.Controllers;
using InvSys.Companies.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Companies.Core.Models;
using Xunit;

namespace InvSys.Companies.Tests.Unit.Api.Controllers
{
    public class CompaniesControllerShould
    {
        [Fact]
        public async Task ReturnListOfCompanies()
        {
            // Given
            var companiesServiceMock = new Mock<ICompaniesService>();
            companiesServiceMock.Setup(service => service.GetCompanies()).Returns(Task.FromResult(new Shared.Builders.Core.CompanyBuilder().CreateListOfSize(5).BuildList()));
            var loggerMock = new Mock<ILogger<CompaniesController>>();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<ICollection<Companies.Api.Models.Company>>(It.IsAny<ICollection<Company>>())).Returns(new Shared.Builders.Api.CompanyBuilder().CreateListOfSize(5).BuildList()).Verifiable();
            var localizerMock = new Mock<IStringLocalizer<CompaniesController>>();
            var companiesController = new CompaniesController(companiesServiceMock.Object, loggerMock.Object, mapperMock.Object, localizerMock.Object);

            // When
            var result = await companiesController.Get();

            // Then
            var okResult = Assert.IsType<OkObjectResult>(result);
            var companies = Assert.IsType<List<Companies.Api.Models.Company>>(okResult.Value);
            mapperMock.Verify();
            Assert.Equal(5, companies.Count);
        }
    }
}
