using BookingV2.Application.Configurations;
using BookingV2.Domain.DTOs;
using BookingV2.Domain.Entities;
using BookingV2.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookingV2.Application.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        #region Constructor 
        private readonly UserManager<Person> _personManager;
        private readonly CustomTokenOption _customTokenOption;

        public TokenRepository(UserManager<Person> personManager, IOptions<CustomTokenOption> customTokenOption)
        {
            _personManager = personManager;
            _customTokenOption = customTokenOption.Value;
        }
        #endregion

        #region CreateRefreshToken
        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
        #endregion

        #region GetClaims
        private async Task<IEnumerable<Claim>> GetClaims(Person personApp, List<String> audiences)
        {
            var userRoles = await _personManager.GetRolesAsync(personApp);
            var userList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, personApp.Id),
                new Claim(JwtRegisteredClaimNames.Email, personApp.Email),
                new Claim(ClaimTypes.Name, personApp.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            userList.AddRange(audiences.Select(r => new Claim(JwtRegisteredClaimNames.Aud, r)));
            userList.AddRange(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));
            return userList;
        }
        #endregion


        #region CreateToken
        public TokenDto CreateToken(Person personApp)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_customTokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_customTokenOption.RefreshTokenExpiration);
            var securityKey = SignRepository.GetSymmetricSecurityKey(_customTokenOption.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: _customTokenOption.Issuer,
                    expires: accessTokenExpiration,
                    notBefore: DateTime.Now,
                    claims: GetClaims(personApp, _customTokenOption.Audience).Result,
                    signingCredentials: signingCredentials
                );
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);
            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };
            return tokenDto;
        }
        #endregion
    }
}
