using BookingV2.Application.AuthorF.Commands;
using BookingV2.Application.BookF.Command;
using BookingV2.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingV2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpPost("AddBook")]
        public async Task<IActionResult> Register([FromServices] IMediator mediator, AddBookDto bookDto)
        {

            var author = new AddBookCommand { Isbn = bookDto.Isbn, Name = bookDto.Name, AuthorId = bookDto.AuthorId };
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
    }
}
