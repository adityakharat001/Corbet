using Corbet.Application.Models.Mail;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
