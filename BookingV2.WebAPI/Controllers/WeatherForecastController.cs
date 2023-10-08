using BookingV2.Application.PersonF.Commands;
using BookingV2.Application.PersonF.Queries;
using BookingV2.Domain.DTOs;
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
                // Person nesnesi bulunduğunda 200 OK yanıtını döndürün.
                return Ok(person);
            }
            else
            {
                // Person nesnesi bulunamadığında 404 Not Found yanıtını döndürün.
                return NotFound();
            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromServices] IMediator mediator, CreatePersonDto createPersonDto)
        {

            var createPerson = new CreatePerson { Email = createPersonDto.Email, Password = createPersonDto.Password, UserName = createPersonDto.UserName};
            var person = await mediator.Send(createPerson);

            if (person != null)
            {
                // Person nesnesi bulunduğunda 200 OK yanıtını döndürün.
                return Ok(person);
            }
            else
            {
                // Person nesnesi bulunamadığında 404 Not Found yanıtını döndürün.
                return NotFound();
            }
        }
    }
}