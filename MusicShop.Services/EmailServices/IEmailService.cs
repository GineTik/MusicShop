using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Core.WebHost.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.EmailServices
{
    public interface IEmailService
    {
        void SendEmail(User user, string htmlBodyTemplate, string subject = null);   
        void SendEmail(IList<User> users, string htmlBodyTemplate, string subject = null);
        void ConfirmEmail(UserResponse user, string pathToTemplate, string subject);
    }
}
