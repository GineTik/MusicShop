using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.AuthorizationServices
{
    public interface ITokenServices
    {
        string BuildToken(string key, string issuer, string audience, User user);
        bool IsTokenValid(string key, string issuer, string audience, string token);
    }
}
