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
            var systemClock = new FakeSystemClock(today);
            var expectedWeather = new WeatherForecast()
            {
                Day = today,
                Weather = 10.3
            };
            var controller = new WeatherController(systemClock);

            var actualWeather = controller.GetWeather();
            
            Assert.Equal(actualWeather.Day, expectedWeather.Day);
            Assert.Equal(actualWeather.Weather, expectedWeather.Weather);
        }
    }

    public interface ISystemClock
    {
        DateTime UtcNow { get; }
    }

    public class FakeSystemClock : ISystemClock
    {
        public DateTime UtcNow { get; }

        public FakeSystemClock(DateTime today)
        {
            UtcNow = today;
        }
    }

    public class WeatherController
    {
        private readonly ISystemClock _systemClock;

        public WeatherController(ISystemClock systemClock)
        {
            _systemClock = systemClock;
        }

        public WeatherForecast GetWeather()
        {
            return new WeatherForecast
            {
                Day = _systemClock.UtcNow,
                Weather = 10.3
            };
        }
    }

    public class WeatherForecast
    {
        public DateTime Day { get; set; }
        public double Weather { get; set; }
    }
}