using System;

namespace WeatherApi.Infrastructure
{
    public interface ISystemClock
    {
        DateTime UtcNow { get; }
    }
}