using Microsoft.AspNetCore.Mvc;
using WebApiGitHubActionsTest.Services;

namespace WebApiGitHubActionsTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ForeCastService _forecastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ForeCastService forecastService, ILogger<WeatherForecastController> logger)
        {
            _forecastService = forecastService;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecastService.GetForecasts(5);
        }

        [HttpGet("{date}", Name = "GetWeatherForecastForDate")]
        public WeatherForecast Get(DateOnly date)
        {
            return _forecastService.GetForecastForDate(date);
        }
    }
}
