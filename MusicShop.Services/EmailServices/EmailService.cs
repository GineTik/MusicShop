using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Services.Utils;
using System;
using System.Collections.Generic;

namespace MusicShop.Services.EmailServices
{
    public class EmailService : IEmailService
    {

        private EmailSender _emailSender; 
        public EmailService(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void ConfirmEmail(UserResponse user, string pathToTemplate, string subject)
        {
            HtmlContent htmlContent = new HtmlContent(FileManager.ReadFile(pathToTemplate));
            htmlContent.AppendValue("name", user.Username);
            htmlContent.AppendValue("token", user.Token);

            _emailSender.Send(user.Email, subject, htmlContent.Render());
        }

        public void SendEmail(User user, string htmlBodyTemplate, string subject = null)
        {
            _emailSender.Send(user.Email, subject, htmlBodyTemplate);
        }

        public void SendEmail(IList<User> users, string htmlBodyTemplate, string subject = null)
        {
            throw new NotImplementedException();
        }
    }
}
