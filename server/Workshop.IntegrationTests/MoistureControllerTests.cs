using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Workshop.IntegrationTests
{
    public class LicensesControllerTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;

        public LicensesControllerTests(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/Moisture")]
        [InlineData("/moisture")]
        public async Task Humidity_Always_ReturnsOk(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);
        }

        [Theory]
        [InlineData("/mossture")]
        [InlineData("/what")]
        public async Task Get_InvalidRoute_ReturnsNotFound(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, (int)response.StatusCode);
        }
    }

}