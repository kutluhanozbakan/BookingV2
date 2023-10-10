using BookingV2.Application.AuthorF.Commands;
using BookingV2.Application.AuthorF.Queries;
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
    public class AuthorController : CustomBaseController
    {
        [HttpPost("AddAuthor")]
        public async Task<IActionResult> Register([FromServices] IMediator mediator, AuthorDto createPersonDto)
        {

            var author = new AddAuthor { Name = createPersonDto.Name, Surname = createPersonDto.Surname };
            var response = await mediator.Send(author);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("GetAllAuthor")]
        public async Task<IActionResult> GetAllAuthor([FromServices] IMediator mediator)
        {
            var getAllAuthor = new GetAllAuthor();
            var allauthor = await mediator.Send(getAllAuthor);

            if (allauthor != null)
            {
                return Ok(allauthor);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
