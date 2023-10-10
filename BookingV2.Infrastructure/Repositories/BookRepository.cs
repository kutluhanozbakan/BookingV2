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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Response<List<Book>>> GetBookByAuthorID(int authorID)
        {
            var list = _appDbContext.Book.Where(x=> x.authorId == authorID).ToList();
            List<AuthorDto> result = new List<AuthorDto>();
            
            return Response<List<Book>>.Success(list, StatusCodes.Status200OK);
        }
    }
}
