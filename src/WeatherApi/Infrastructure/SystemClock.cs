using System;

namespace WeatherApi.Infrastructure
{
    public class SystemClock : ISystemClock
    {
        public DateTime UtcNow { get; } = DateTime.UtcNow;
    }
}