using Microsoft.AspNetCore.Mvc;
using WeatherApi.Infrastructure;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly ISystemClock _systemClock;

        public WeatherController(ISystemClock systemClock)
        {
            _systemClock = systemClock;
        }

        [HttpGet]
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