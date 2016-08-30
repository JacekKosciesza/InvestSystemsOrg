using InvSys.Email.Api;
using InvSys.Email.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        public async Task ReturnTemplates()
        {
            // Act
            var response = await _client.GetAsync("/api/templates");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var templates = JsonConvert.DeserializeObject<List<Template>>(responseString);
            Assert.NotEmpty(templates);
        }

        [Fact]
        public async Task ReturnTemplate()
        {
            // Act
            var id = "068f090c-b939-4ace-b22c-e4b8776b4754";
            var response = await _client.GetAsync($"/api/templates/{id}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var template = JsonConvert.DeserializeObject<Template>(responseString);
            Assert.NotNull(template);
            Assert.Equal(new Guid(id), template.Id);
        }

        [Fact]
        public async Task ReturnCreatedTemplate()
        {
            // Act
            var template = new Template
            {
                Id = Guid.NewGuid(),
                Title = "Test template title",
                Name = "Test template name",
                Description = "Test template description",
                Body = "Test template body"
            };
            var content = JsonConvert.SerializeObject(template);
            var response = await _client.PostAsync($"/api/templates", new StringContent(content, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var template2 = JsonConvert.DeserializeObject<Template>(responseString);
            Assert.NotNull(template2);
            Assert.Equal(template.Id, template2.Id);
        }
    }
}
