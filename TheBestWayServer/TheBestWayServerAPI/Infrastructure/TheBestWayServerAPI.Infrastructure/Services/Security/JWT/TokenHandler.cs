using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Security.JWT;
using TheBestWayServerAPI.Application.Dtos.Tokens;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Infrastructure.Services.Security.JWT
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly DateTime _accessTokenExpirationDate;
        private readonly DateTime _refreshTokenExpirationDate;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _accessTokenExpirationDate = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["TokenOptions:AccessTokenExpiration"]));
            _refreshTokenExpirationDate = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["TokenOptions:RefreshTokenExpiration"]));
        }

        public TokenDto CreateAccessTokenAndRefreshToken(User user)
        {
            System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtSecurityToken = TokenConfigurationGenerator(user);
            //token oluşturucu sınıftan örnek alınıyor.
            System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            //token yazılıyor.
            string accessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return new TokenDto()
            {
                AccessToken = accessToken,
                AccessTokenExpirationDate = _accessTokenExpirationDate,
                RefreshToken = CreateRefreshToken(),
                RefreshTokenExpirationDate = _refreshTokenExpirationDate
            };
        }

        private JwtSecurityToken TokenConfigurationGenerator(User user)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));
            //şifrelenmiş kimlik oluşturuluyor.
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            //oluşturulacak token ayarları vriliyor.
            System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtSecurityToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
               issuer: _configuration["TokenOptions:Issuer"],//tüetici
               audience: _configuration["TokenOptions:Audience"],//üretici
               claims: GetClaims(user),
               notBefore: DateTime.Now,//ne kadar sonra devreye girecek
               expires: _accessTokenExpirationDate,//kaç dk süresi olacak
               signingCredentials: signingCredentials//şifreleme tipi
                );
            return jwtSecurityToken;
        }

        private IEnumerable<Claim> GetClaims(User user)     
        {
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            return userClaims;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }


    }
}
