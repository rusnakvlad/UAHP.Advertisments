using Advertisment.DAL.EF;
using Advertisment.DAL.Enteties;
using Advertisment.DAL.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AdvertismentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private IUserRepository userRepository;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            _logger = logger;
            this.userRepository = userRepository;
            var result = dbContext.Users;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //User result = Task.Run(async () => await userRepository.GetAllAsync("GetAllUsers")).Result.First();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
               // Summary = result.Surname
            })
            .ToArray();
        }
    }
}