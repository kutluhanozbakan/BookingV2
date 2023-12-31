﻿using BookingV2.Domain.Entities;
using BookingV2.SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Domain.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Response<List<Book>>> GetBookByAuthorID(int authorID);
    }
}
