using BookingV2.Application.AuthorF.Commands;
using BookingV2.Application.AuthorF.Queries;
using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using BookingV2.SharedLibrary.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.AuthorF.QueryHandlers
{
    public class GetAllAuthorHandler : IRequestHandler<GetAllAuthor, List<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAllAuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<List<Author>>Handle(GetAllAuthor request, CancellationToken cancellationToken)
        {
            var list = _authorRepository.GetAll();
            List<Author> authorList = list.ToList();

            return Task.FromResult(authorList);

        }
    }
}
