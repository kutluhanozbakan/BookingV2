using BookingV2.Application.Auth.Queries;
using BookingV2.Application.PersonF.Commands;
using BookingV2.Application.PersonF.Queries;
using BookingV2.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingV2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromServices] IMediator mediator, CreatePersonDto createPersonDto)
        {

            var createPerson = new CreatePerson { Email = createPersonDto.Email, Password = createPersonDto.Password, UserName = createPersonDto.UserName };
            var person = await mediator.Send(createPerson);

            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromServices] IMediator mediator, LoginDto loginDto)
        {
            var login = new Login { Email = loginDto.Email, Password = loginDto.Password };
            var person = await mediator.Send(login);
            return ActionResultInstance(person);

        }

        [HttpGet("GetPersonById/{id}")]
        public async Task<IActionResult> GetPersonById([FromServices] IMediator mediator, int id)
        {
            var getPerson = new GetPersonById { Id = id };
            var person = await mediator.Send(getPerson);

            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
