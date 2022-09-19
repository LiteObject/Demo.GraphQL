using Demo.Weather.Shared.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Weather.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CityWeatherDbContext _cityWeatherDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CityWeatherDbContext cityWeatherDbContext)
        {
            _logger = logger;
            _cityWeatherDbContext = cityWeatherDbContext;
        }

        [HttpGet(Name = "{cityName}")]
        public async Task<IActionResult> Get(string cityName)
        {
            var result = await _cityWeatherDbContext.Cities.Include(c => c.WeatherForecasts).Where(c => c.Name.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToListAsync();

            if (result is null || result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}