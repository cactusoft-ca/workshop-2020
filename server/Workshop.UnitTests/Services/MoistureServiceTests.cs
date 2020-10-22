using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.Protected;
using Workshop.Api.Services;
using Xunit;

namespace Workshop.UnitTests.Services
{
    public class MoistureServiceTests
    {
        private IMoistureService MoistureService { get; }
        private Mock<IHttpClientFactory> HttpClientFactoryMock { get; }
        private Mock<HttpMessageHandler> HttpMessageHandlerMock { get; }

        public MoistureServiceTests()
        {
            HttpMessageHandlerMock = new Mock<HttpMessageHandler>();
            HttpClientFactoryMock = new Mock<IHttpClientFactory>();
            HttpClientFactoryMock
                .Setup(_ => _.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(HttpMessageHandlerMock.Object));

            MoistureService = new MoistureService(HttpClientFactoryMock.Object, NullLogger<MoistureService>.Instance);
        }

        #region GetRawMoisture

        [Fact]
        public async Task GetMoistureRaw_ValidValueAndOk_ReturnsValue()
        {
            // Arrange
            SetupMoisture("123");

            // Act
            var actual = await MoistureService.GetMoistureRaw();

            // Assert
            Assert.Equal(123, actual);
        }

        [Fact]
        public async Task GetMoistureRaw_InvalidValueAndOk_Throws()
        {
            // Arrange
            SetupMoisture("invalid");

            // Act
            await Assert.ThrowsAsync<MoistureService.MoistureInvalidValueException>(() => MoistureService.GetMoistureRaw());
        }

        [Fact]
        public async Task GetMoistureRaw_ValidValueBadRequest_Throws()
        {
            // Arrange
            SetupMoisture("123", HttpStatusCode.BadRequest);

            // Act
            await Assert.ThrowsAsync<MoistureService.MoistureApiException>(() => MoistureService.GetMoistureRaw());
        }

        #endregion

        #region Helpers

        private void SetupMoisture(string moisture, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            HttpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(moisture)
                });
        }

        #endregion
    }
}
