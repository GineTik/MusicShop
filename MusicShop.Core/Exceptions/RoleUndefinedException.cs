using System;

namespace MusicShop.Core.Exceptions
{
    public class RoleUndefinedException : Exception
    {
        public RoleUndefinedException() : base("The role is not found")
        { }
    }
}
