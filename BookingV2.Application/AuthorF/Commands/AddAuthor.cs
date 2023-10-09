using MediatR;
using System;
using System.Collections.Generic;
using BookingV2.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingV2.Domain.DTOs;
using BookingV2.SharedLibrary.Dtos;

namespace BookingV2.Application.AuthorF.Commands
{
    public class AddAuthor : IRequest<Response<AuthorDto>>
    {
        public string Name { get;  set; }
        public string Surname { get;  set; }
    }
}
