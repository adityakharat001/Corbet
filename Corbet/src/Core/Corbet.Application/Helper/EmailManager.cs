using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using MimeKit;
using MimeKit.Text;
using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;
using System.Web;

namespace Corbet.Application.Helper
{
    public class EmailManager : IDisposable
    {
        private readonly IConfiguration _configuration;

        public EmailManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void SendEmail(string mEmail, int userId)
        {
            string emailHost, userEmail, emailPassword;
            emailHost = _configuration.GetSection("EmailSettings").GetSection("Host").Value;
            userEmail = _configuration.GetSection("EmailSettings").GetSection("Mail").Value;
            emailPassword = _configuration.GetSection("EmailSettings").GetSection("Password").Value;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(userEmail));
            email.To.Add(MailboxAddress.Parse(mEmail));
            email.Subject = "Reset Your Password";
            var encryptedUserId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(userId.ToString()));
            var lnkHref = $"<button><a href='https://localhost:7221/Login/ResetPassword?userId={encryptedUserId}'>Reset Password</a></button>";
            var content1 = "Hello, You have requested us to send a link to reset your password for your Corbet account.";
            var content2 = "If you didn't initiate this request, you can safely ignore this email.";
            var content = content1 + "<br/>" + "Click on " + lnkHref + " to reset your password." + "<br/>" + content2 + "<br/>" + "Thanks!<br/>Team Corbet.";
            email.Body = new TextPart(TextFormat.Html) { Text = content};
            var smtp = new SmtpClient();
            smtp.Connect(emailHost, 587, SecureSocketOptions.StartTls);//host and port
            smtp.Authenticate(userEmail, emailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
