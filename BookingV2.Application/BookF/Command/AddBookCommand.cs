using BookingV2.Domain.Entities;
using BookingV2.SharedLibrary.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.BookF.Command
{
    public class AddBookCommand : IRequest<Response<Book>>
    {
        public string Name { get; set; }
        public string Isbn { get;  set; }
        public int AuthorId { get;  set; }
    }
}
