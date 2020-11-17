using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials;

namespace BlazorHybrid
{
    public class CounterState
    {
        private readonly ILogger<CounterState> _logger;
        private readonly IConfiguration _configuration;

        public CounterState(ILogger<CounterState> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public int CurrentCount { get; private set; }

        public void IncrementCount()
        {
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                CurrentCount++;
            }
            else
            {
                CurrentCount += int.Parse(_configuration["CounterValue"]);
            }
            StateChanged?.Invoke();
            _logger.LogInformation("Current count: {count}", CurrentCount);
        }

        public event Action StateChanged;
    }
}