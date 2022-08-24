using GlobalLogic.ShopApp.Core.AggregatesModel.ApplicationUserAggregate;
using GlobalLogic.ShopApp.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalLogic.ShopApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly ITokenProvider tokenProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IApplicationUserRepository applicationUserRepository,
            ITokenProvider tokenProvider)
        {
            _logger = logger;
            this.applicationUserRepository = applicationUserRepository;
            this.tokenProvider = tokenProvider;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            this.tokenProvider.GetToken(new ApplicationUser("test", "dafwag"));
            applicationUserRepository.AddAsync(new ApplicationUser("test", "dafwag"));

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}