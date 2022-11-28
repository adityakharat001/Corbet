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

        public void SendEmail(string mEmail)
        {
            string emailHost, userEmail, emailPassword;
            emailHost = _configuration.GetSection("EmailSettings").GetSection("Host").Value;
            userEmail = _configuration.GetSection("EmailSettings").GetSection("Mail").Value;
            emailPassword = _configuration.GetSection("EmailSettings").GetSection("Password").Value;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(userEmail));
            email.To.Add(MailboxAddress.Parse(mEmail));
            email.Subject = "Reset Your Password!";
            var lnkHref = $"<button><a href='https://localhost:7221/Login/ResetPassword?email={mEmail}'>Reset Password</a></button>";
            email.Body = new TextPart(TextFormat.Html) { Text = "Dear User, <br/><br/>Please refer to link below to reset your password.<br/><b>Please find the Password Reset Link. </b><br/>" + lnkHref + "<br/> Regards, <br/> Team.Support"};
            var smtp = new SmtpClient();
            smtp.Connect(emailHost, 587, SecureSocketOptions.StartTls);//host and port
            smtp.Authenticate(userEmail, emailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}

