using BookingV2.Application.AuthorF.Queries;
using BookingV2.Application.BookF.Queries;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using BookingV2.SharedLibrary.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.BookF.QueryHandlers
{
    internal class GetBookByAuthorIdHandler : IRequestHandler<GetBookByAuthorId, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByAuthorIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetBookByAuthorId request, CancellationToken cancellationToken)
        {
            var list = _bookRepository.GetBookByAuthorID(request.AuthorId);

            return list.Result.Data;
        }
    }
}
