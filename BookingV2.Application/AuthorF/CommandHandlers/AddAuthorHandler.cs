


using BookingV2.Application.AuthorF.Commands;
using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using BookingV2.Infrastructure.SeedWorks;
using BookingV2.SharedLibrary.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;

namespace BookingV2.Application.AuthorF.CommandHandlers
{
    public class AddAuthorHandler : IRequestHandler<AddAuthor, Response<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        


        public AddAuthorHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _authorRepository = authorRepository;
        }

        public async Task<Response<AuthorDto>> Handle(AddAuthor request, CancellationToken cancellationToken)
        {
            var author = new Author(request.Name, request.Surname);

            var result = await _authorRepository.AddAuthor(author);
            return result;
        }

    }
}


