using Newtonsoft.Json.Linq;
using System.Net;
using Xunit;
using InvSys.Shared.Tests.Requests;

namespace InvSys.Companies.Tests.Integration.Swagger
{
    public class SwashbuckleShould
    {
        [Fact]
        public async void ReturnSwaggerJson()
        {
            // Given
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:5001/swagger/v1/swagger.json"); // TODO: move URL to configuration?
            request.Method = "GET";
            request.ContentType = "application/json";

            // When
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var streamContent = await response.GetStreamContent();
                JObject json = JObject.Parse(streamContent);

                // Then
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal("Companies API", (string)json["info"]["title"]); // TODO: Get title from configuration
            }
        }
    }
}
