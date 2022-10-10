using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace MusicShop.Services.AuthorizationServices
{
    public class TokenServices : ITokenServices
    {
        public string BuildToken(string key, string issuer,string audience, User user)
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


            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim( ClaimTypes.Email, user.Email),
                    new Claim("Id", user.Id.ToString())
                },
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

       

        public bool IsTokenValid(string key, string issuer, string audience, string token)
        {
            throw new NotImplementedException();
        }
    }
}
