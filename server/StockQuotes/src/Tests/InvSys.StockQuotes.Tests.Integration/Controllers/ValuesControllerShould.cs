using InvSys.StockQuotes.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace InvSys.StockQuotes.Tests.Integration.Controllers
{
    public class ValuesControllerShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ValuesControllerShould()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnValues()
        {
            // Act
            var response = await _client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("value1", responseString);
        }
    }
}
