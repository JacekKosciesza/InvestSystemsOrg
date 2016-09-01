using InvSys.Watchlists.Api;
using InvSys.Watchlists.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InvSys.Watchlists.Tests.Integration.Controllers
{
    public class WatchlistsControllerShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public WatchlistsControllerShould()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnWatchlists()
        {
            // Act
            var response = await _client.GetAsync("/api/watchlists");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var templates = JsonConvert.DeserializeObject<List<Watchlist>>(responseString);
            Assert.NotEmpty(templates);
        }

        [Fact]
        public async Task ReturnWatchlist()
        {
            // Act
            var id = "6e274718-69d8-4f7a-8f08-2f868182c758";
            var response = await _client.GetAsync($"/api/watchlists/{id}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var template = JsonConvert.DeserializeObject<Watchlist>(responseString);
            Assert.NotNull(template);
            Assert.Equal(new Guid(id), template.Id);
        }

        [Fact]
        public async Task ReturnCreatedWatchlist()
        {
            // Act
            var watchlist = new Watchlist
            {
                Id = Guid.NewGuid(),
                Culture = "en-US",
                UserId = new Guid("c6c746fd-e2da-4f3b-8417-6b7716421133"),
                UserName = "jkosciesza",
                Name = "Test watchlist",
                Description = "Test watchlist description",
                Items = new List<Item>
                {
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        CompanyId = new Guid("40eb767e-9a67-42c7-b907-66f7a0ef8642"),
                        CompanySymbol = "The company"
                    }
                }
            };
            var content = JsonConvert.SerializeObject(watchlist);
            var response = await _client.PostAsync($"/api/watchlists", new StringContent(content, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var createdWatchlist = JsonConvert.DeserializeObject<Watchlist>(responseString);
            Assert.NotNull(createdWatchlist);
            Assert.Equal(watchlist.Id, createdWatchlist.Id);
        }
    }
}
