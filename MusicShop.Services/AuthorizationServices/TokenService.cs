﻿using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace MusicShop.Services.AuthorizationServices
{
    public class TokenService : ITokenService
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;

        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            
            _key = _configuration["Jwt:Key"];
            _issuer = _configuration["Jwt:Issuer"];
            _audience = _configuration["Jwt:Audience"];
        }


        public string BuildToken(User user)
        {
            // Тут буде бато проблем
            // Важливо дотримуватись регламенту 
            // ---------------------------------------------------------------------------------
            // Для юзерів мб краще створити окремий метод який повертає клейми
            // Є декілька других підходів для створення токена, з хендлером та дескриптором.
            // ---------------------------------------------------------------------------------
            // Мабуть, краще робити іншу реалізацію інтерфейсу, з різними підходами. Зручніше тестувати
            // ---------------------------------------------------------------------------------
            // В клейми додати роль юзера 

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (user.Role == null)
                throw new ArgumentNullException(nameof(user.Role));

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new[]
                {
                    new Claim( ClaimTypes.Email, user.Email),
                    new Claim( "UserId", user.Id.ToString()),
                    new Claim( ClaimTypes.Role, user.Role.Name )
                    
                },
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

       

        public bool IsTokenValid(string token)
        {
            if (String.IsNullOrEmpty(token))
                throw new ArgumentException(nameof(token));

            var keyBytes = Encoding.UTF8.GetBytes(_key);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true, 
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = securityKey
                }, out SecurityToken validToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
