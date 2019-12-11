using System.Threading.Tasks;
using Xunit;

namespace WeatherApi.Test
{
    public class WeatherApiIntegrationTest
        : IClassFixture<WeatherApiWebApplicationFactory<Startup>>
    {
        private readonly WeatherApiWebApplicationFactory<Startup> _factory;

        public WeatherApiIntegrationTest(WeatherApiWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetSucceeds()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/weather");

            response.EnsureSuccessStatusCode();
        }
    }
}