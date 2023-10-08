using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using BookingV2.Infrastructure.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.Repositories
{
    public class AuthanticationRepository :  IAuthenticationRepository
    {
        #region Constructor
        private readonly ITokenRepository _tokenRepository;
        private readonly UserManager<Person> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<PersonRefreshToken> _personRefreshTokenRepository;


        public AuthanticationRepository(ITokenRepository tokenRepository, UserManager<Person> userManager, IUnitOfWork unitOfWork, IGenericRepository<PersonRefreshToken> personRefreshTokenRepository)
        {
            _tokenRepository = tokenRepository;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _personRefreshTokenRepository = personRefreshTokenRepository;
        }
        #endregion

        #region CreateTokenAsync
        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto is null) throw new ArgumentNullException(nameof(loginDto));
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null) return Response<TokenDto>.Fail("Email or Password is wrong", StatusCodes.Status400BadRequest, true);
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Response<TokenDto>.Fail("Email or Password is wrong", StatusCodes.Status400BadRequest, true);
            var token = _tokenRepository.CreateToken(user);
            var userRefreshToken = await _personRefreshTokenRepository.Where(r => r.UserId == user.Id).SingleOrDefaultAsync();
            if (userRefreshToken is null)
                await _personRefreshTokenRepository.AddAsync(new PersonRefreshToken
                {
                    UserId = user.Id,
                    Code = token.RefreshToken,
                    Expiration = token.RefreshTokenExpiration
                });
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }
            await _unitOfWork.SaveChangesAsync();
            return Response<TokenDto>.Success(token, StatusCodes.Status200OK);
        }
        #endregion

        #region CreateTokenByRefreshToken
        public async Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _personRefreshTokenRepository.Where(r => r.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken is null) return Response<TokenDto>.Fail("RefreshToken not found", StatusCodes.Status404NotFound, true);
            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user is null) return Response<TokenDto>.Fail("UserID not found", StatusCodes.Status404NotFound, true);
            var tokenDto = _tokenRepository.CreateToken(user);
            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;
            await _unitOfWork.SaveChangesAsync();
            return Response<TokenDto>.Success(tokenDto, StatusCodes.Status200OK);
        }
        #endregion

        #region RevokeRefreshToken
        public async Task<Response<NoDataDto>> RevokeRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken = await _personRefreshTokenRepository.Where(r => r.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken is null) return Response<NoDataDto>.Fail("RefreshToken not found", StatusCodes.Status404NotFound, true);
            _personRefreshTokenRepository.Remove(existRefreshToken);
            await _unitOfWork.SaveChangesAsync();
            return Response<NoDataDto>.Success(StatusCodes.Status200OK);
        }
        #endregion
    }
}
