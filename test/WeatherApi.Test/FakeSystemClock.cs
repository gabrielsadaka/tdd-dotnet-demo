using System;
using WeatherApi.Infrastructure;

namespace WeatherApi.Test
{
    public class FakeSystemClock : ISystemClock
    {
        public DateTime UtcNow { get; }

        public FakeSystemClock(DateTime today)
        {
            UtcNow = today;
        }
    }
}