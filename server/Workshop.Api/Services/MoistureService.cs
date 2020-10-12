using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Workshop.Api.Services
{
    public class MoistureService : IMoistureService
    {
        // TODO: Replace hardcoded value with configured value
        private readonly string _moistureEndpoint = "https://arnold-moisture.herokuapp.com/api/moisture";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<MoistureService> _logger;

        public MoistureService(IHttpClientFactory httpClientFactory, ILogger<MoistureService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<int> GetMoisture()
        {
            using var client = _httpClientFactory.CreateClient();

            try
            {
                _logger.LogInformation($"Getting moisture using endpoint {_moistureEndpoint}.");

                var response = await client.GetStringAsync(_moistureEndpoint);
                if (!int.TryParse(response, out var moisture))
                {
                    _logger.LogError($"{response} is not a valid moisture value.");
                    throw new MoistureInvalidValueException($"{response} is not a valid moisture value.");
                }

                return moisture;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogDebug($"An error occured while calling the Moisture Api: {_moistureEndpoint}.");
                throw new MoistureApiException(_moistureEndpoint, ex);
            }
        }

        public class MoistureInvalidValueException : Exception
        {
            public MoistureInvalidValueException(string val)
                : base($"{val} is not a valid moisture value.") { }
        }

        public class MoistureApiException : Exception
        {
            public MoistureApiException(string endpoint, Exception innerException)
                : base($"An error occured while calling the moisture api using the following endpoint: {endpoint}", innerException) { }
        }
    }
}
