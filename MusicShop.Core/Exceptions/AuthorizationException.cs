using System;

namespace MusicShop.Core.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException()
            : base("Email or/and password not correct")
        { }
    }
}
