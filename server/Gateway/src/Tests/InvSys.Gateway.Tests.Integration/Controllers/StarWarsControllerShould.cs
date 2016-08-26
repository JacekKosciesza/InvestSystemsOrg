using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InvSys.Gateway.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace InvSys.Gateway.Tests.Integration.Controllers
{
    public class StarWarsControllerShould
    {
        private readonly HttpClient _client;

        public StarWarsControllerShould()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact]
        public async Task ReturnValues()
        {
            // Arrange
            var query = @"
              query HeroNameQuery {
                hero {
                  name
                }
              }
            ";

            // Act
            var content = new StringContent("{\"query\":\"" + Regex.Replace(query, @"\s+", " ") + "\"}", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/gql/starwars", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            //var json = JObject.Parse(Regex.Replace(responseString, @"\s+", " "));
            //Assert.Equal("R2-D2", (string)json["data"]["result"]["data"]["hero"]["name"]);
            Assert.Contains("R2-D2", responseString);
        }
    }
}
