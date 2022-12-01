using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.Utils
{
    public class EmailSender
    {
        private SmtpClient _smtpClient;
        private MailAddress _senderEmail;

        public EmailSender(string senderEmail, string passwrod, string name, string host = "smtp.gmail.com", int port = 587, bool enableSsl = true)
        {
            _senderEmail = new MailAddress(senderEmail, name);
            _smtpClient = new SmtpClient(host, port);
            _smtpClient.Credentials = new NetworkCredential(senderEmail, passwrod);
            _smtpClient.EnableSsl = enableSsl;
        }

        public void Send(string email, string title, string content)
        {
            _smtpClient.Send(createMessage(email, title, content));
        }
        private MailMessage createMessage(string email, string title, string htmlContent)
        {
            MailMessage msg = new MailMessage(_senderEmail, new MailAddress(email));
            msg.Subject = title;
            msg.IsBodyHtml = true;
            msg.Body = htmlContent;

            return msg;
        }
    }
}
