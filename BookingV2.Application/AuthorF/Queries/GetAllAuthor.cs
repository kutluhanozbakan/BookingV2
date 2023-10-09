using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.SharedLibrary.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.AuthorF.Queries
{
    public class GetAllAuthor : IRequest<List<Author>>
    {
    }
}
