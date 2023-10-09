using BookingV2.Application.AuthorF.Commands;
using BookingV2.Application.BookF.Command;
using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using BookingV2.Infrastructure.SeedWorks;
using BookingV2.SharedLibrary.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.BookF.CommandHandler
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Response<Domain.Entities.Book>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Book>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var bookR = new Book(request.Name, request.Isbn, request.AuthorId);
            await _bookRepository.AddAsync(bookR);
            _unitOfWork.SaveChangesAsync();
            return Response<Book>.Success(bookR, StatusCodes.Status200OK);
        }
    }
}
