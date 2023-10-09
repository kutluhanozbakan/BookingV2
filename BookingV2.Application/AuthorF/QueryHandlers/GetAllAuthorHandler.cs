using BookingV2.Application.AuthorF.Commands;
using BookingV2.Application.AuthorF.Queries;
using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using BookingV2.SharedLibrary.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IBookRepository _bookRepository;


        public GetAllAuthorHandler(IAuthorRepository authorRepository, IBookRepository bookRepository = null)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public Task<List<Author>>Handle(GetAllAuthor request, CancellationToken cancellationToken)
        {
            var list = _authorRepository.GetAll().ToList(); 

            if (list.Any())
            {
                foreach (var author in list)
                {
                    var books = _bookRepository.Where(x => x.authorId == author.Id).ToList();
                    author.Books = books;
                }
            }

            return Task.FromResult(list);

        }
    }
}
