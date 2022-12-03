using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.Services.EmailServices
{
    public interface IEmailService
    {
        void SendEmail(User user, string htmlBodyTemplate, string subject = null);   
        void SendEmail(IList<User> users, string htmlBodyTemplate, string subject = null);
        void ConfirmEmail(UserResponse user, string pathToTemplate, string subject);
    }
}
