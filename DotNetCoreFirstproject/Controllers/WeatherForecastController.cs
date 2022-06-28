using DotNetCoreFirstproject.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;

namespace DotNetCoreFirstproject.Controllers
{
    [ApiController]
    [Route("rest/api/v1/main/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            //HttpClientHelper<string, string> httpClientHelper = new HttpClientHelper<string, string>();
            //Dictionary<string, string> httpHeaders = new Dictionary<string, string>();

            //httpHeaders.Add(HeaderNames.Accept, "application/json");
            //httpHeaders.Add(HeaderNames.ContentType, "application/json");

            //var cenk = httpClientHelper.MakeRequest("https://www.youtube.com/", "api", "", HttpMethod.Get, httpHeaders);

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