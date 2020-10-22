using System;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Moq.Protected;
using Workshop.Api.Services;
using Xunit;

namespace Workshop.UnitTests
{
    public class MoistureServiceTests
    {
        IMoistureService MoistureService { get; }
        Mock<IHttpClientFactory> HttpClientFactoryMock { get; }
        Mock<HttpMessageHandler> HttpMessageHandlerMock { get; }

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
        public async Task GeRawtMoisture_ValidValueAndOk_ReturnsValue()
        {
            // Arrange
            SetupMoisture("123");

            // Act
            var actual = await MoistureService.GetRawMoisture();

            // Assert
            Assert.Equal(123, actual);
        }

        [Fact]
        public async Task GetRawMoisture_InvalidValueAndOk_Throws()
        {
            // Arrange
            SetupMoisture("invalid");

            // Act
            await Assert.ThrowsAsync<MoistureService.MoistureInvalidValueException>(() => MoistureService.GetRawMoisture());
        }

        [Fact]
        public async Task GetRawMoisture_ValidValueBadRequest_Throws()
        {
            // Arrange
            SetupMoisture("123", HttpStatusCode.BadRequest);

            // Act
            await Assert.ThrowsAsync<MoistureService.MoistureApiException>(() => MoistureService.GetRawMoisture());
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
