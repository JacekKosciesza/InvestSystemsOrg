using InvSys.Email.Api;
using InvSys.Email.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace InvSys.Email.Tests.Integration.Controllers
{
    public class TemplatesControllerShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TemplatesControllerShould()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnAllTemplates()
        {
            // Act
            var response = await _client.GetAsync("/api/templates");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var templates = JsonConvert.DeserializeObject<List<Template>>(responseString);
            Assert.NotEmpty(templates);
        }
    }
}
