using System;
using Xunit;

namespace WeatherApi.Test
{
    public class WeatherApiControllerTest
    {
        [Fact]
        public void GetShouldReturnWeatherForToday()
        {
            var today = new DateTime(2019, 03, 10);
            var expectedWeather = new WeatherForecast()
            {
                Day = today,
                Weather = 10.3
            };
            var controller = new WeatherController();

            var actualWeather = controller.GetWeather();
            
            Assert.Equal(actualWeather.Day, expectedWeather.Day);
            Assert.Equal(actualWeather.Weather, expectedWeather.Weather);
        }
    }
}