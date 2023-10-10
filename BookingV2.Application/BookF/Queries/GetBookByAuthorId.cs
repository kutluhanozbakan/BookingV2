using BookingV2.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.BookF.Queries
{
    public class GetBookByAuthorId : IRequest<List<Book>>
    {
        public int AuthorId { get; set; }
    }
}
