using InvSys.Identity.Api;
using InvSys.Identity.Api.Client.Proxy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace InvSys.Identity.Tests.Integration.Api.Controllers
{
    public class UsersControllerShould
    {
        //private readonly TestServer _server;
        //private readonly HttpClient _client;
        private readonly IIdentityAPI client;
        IConfigurationRoot _configuration;

        public UsersControllerShould()
        {
            // Arrange
            var builder = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();
            //_server = new TestServer(new WebHostBuilder()
            //    .UseStartup<Startup>());
            //_client = _server.CreateClient();
            //client = new IdentityAPI(_server.BaseAddress);
            client = new IdentityAPI(new Uri(_configuration["Client:Url"], UriKind.Absolute));
        }

        [Fact]
        public async void ReturnAnyUser()
        {
            // When
            var users = await client.GetUsersAsync();

            // Then
            Assert.NotNull(users);
            Assert.NotNull(users.Any());
        }
    }
}
