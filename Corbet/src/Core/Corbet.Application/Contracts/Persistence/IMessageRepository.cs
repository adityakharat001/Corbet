using Corbet.Domain.Entities;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IMessageRepository : IAsyncRepository<Message>
    {
        public Task<Message> GetMessage(string Code, string Lang);
    }
}
