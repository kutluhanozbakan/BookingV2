using BookingV2.Application.PersonF.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingV2.WebAPI.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("GetPersonById/{id}")]
        public async Task<IActionResult> GetPersonById([FromServices] IMediator mediator, int id)
        {
            var getPerson = new GetPersonById { Id = id };
            var person = await mediator.Send(getPerson);

            if (person != null)
            {
                // Person nesnesi bulunduðunda 200 OK yanýtýný döndürün.
                return Ok(person);
            }
            else
            {
                // Person nesnesi bulunamadýðýnda 404 Not Found yanýtýný döndürün.
                return NotFound();
            }
        }

    }
}