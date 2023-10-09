using BookingV2.Domain;
using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using BookingV2.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Response<AuthorDto>> AddAuthor(Author authorDto)
        {
            await _appDbContext.Author.AddAsync(authorDto);
            return Response<AuthorDto>.Success(null, StatusCodes.Status200OK);
        }


    }
}
