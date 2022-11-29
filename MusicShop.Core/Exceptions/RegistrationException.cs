using System;

namespace MusicShop.Core.Exceptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException() 
            : base("The user with this email exists")
        { }
    }
}
