using System.Net.Http;

namespace Workshop.UnitTests.Helpers
{
    public class TestHttpClientFactory : IHttpClientFactory
    {
        private readonly HttpClient _client;

        public TestHttpClientFactory(HttpClient client)
        {
            _client = client;
        }

        public HttpClient CreateClient(string name = null)
        {
            return _client;
        }
    }
}
