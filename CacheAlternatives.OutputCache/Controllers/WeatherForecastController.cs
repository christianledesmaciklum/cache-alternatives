using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace CacheAlternatives.OutputCache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [OutputCache]
        public string Get()
        {
            return "Hello";
        }

        [HttpGet]
        // We can use custom policy defined un Program.cs -> .AddOutputCache()
        [OutputCache(PolicyName = "Custom-Policy")]
        public string Get2()
        {
            return "Hello";
        }

        [HttpGet]
        // We can use inline settings
        [OutputCache(Duration = 10)]
        public string Get3()
        {
            return "Hello";
        }
    }
}
