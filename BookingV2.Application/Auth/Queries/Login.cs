using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.SharedLibrary.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.Auth.Queries
{
    public class Login : IRequest<Response<TokenDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
