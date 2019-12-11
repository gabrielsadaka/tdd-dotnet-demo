using System.Threading.Tasks;
using Newtonsoft.Json;
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

            var response = await client.GetAsync("/api/weather");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetReturnsWeather()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/weather");

            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic responseObject = JsonConvert.DeserializeObject(responseContent);

            Assert.Equal(10.3, (double)responseObject.weather);
        }
    }
}