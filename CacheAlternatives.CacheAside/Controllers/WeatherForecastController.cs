using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CacheAlternatives.CacheAside.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private const string WeatherKey = "Weather";

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCache _cache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var cachedResult = _cache.Get<IEnumerable<WeatherForecast>>(WeatherKey);
            if (cachedResult is not null)
                return cachedResult;

            var weatherValue = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            _cache.Set(WeatherKey, weatherValue);

            // OR YOU CAN USE CUSTOM OPTIONS IF YOU WISH
            _cache.Set(WeatherKey, weatherValue, new MemoryCacheEntryOptions());
            return weatherValue;
        }
    }
}
