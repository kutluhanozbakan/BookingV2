using BookingV2.Application.Auth.Queries;
using BookingV2.Application.PersonF.Queries;
using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.Auth.QueryHandlers
{
    public class LoginHandler : IRequestHandler<Login, Response<TokenDto>>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public LoginHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<Response<TokenDto>> Handle(Login request, CancellationToken cancellationToken)
        {
            LoginDto loginDto = new LoginDto()
            {
                Email = request.Email,
                Password = request.Password,
            };
            var a = await _authenticationRepository.CreateTokenAsync(loginDto);
            return a;
        }

        //async Task<LoginDto> IRequestHandler<Login, LoginDto>.Handle(Login request, CancellationToken cancellationToken)
        //{
        //    LoginDto loginDto = new LoginDto() { 
        //    Email = request.Email,
        //    Password = request.Password,
        //    };
        //    await _authenticationRepository.CreateTokenAsync(loginDto);
        //    return loginDto;
        //}
    }
}
