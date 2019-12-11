using WeatherApi.Infrastructure;

namespace WeatherApi.Controllers
{
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
}