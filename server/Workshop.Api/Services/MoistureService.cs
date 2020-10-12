using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Workshop.Api.Services
{
    public class MoistureService : IMoistureService
    {
        // TODO: Replace hardcoded value with configured value
        private readonly string _moistureEndpoint = "https://arnold-moisture.herokuapp.com/api/moisture";
        private readonly IHttpClientFactory _httpClientFactory;

        public MoistureService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetMoisture()
        {
            using var client = _httpClientFactory.CreateClient();

            try
            {

                var response = await client.GetStringAsync(_moistureEndpoint);
                if (!int.TryParse(response, out var moisture))
                {
                    throw new MoistureInvalidValueException($"Cannot cast {response} to moisture value.");
                }

                return moisture;
            }
            catch (HttpRequestException ex)
            {
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
