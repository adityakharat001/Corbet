using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IStockRepository : IAsyncRepository<Stock>
    {
        Task<Stock> GetByProductIdAsync(int productId);
        Task<Stock> GetByIdAsync(int stockId);
        Task<bool> CheckProductExistsInStockList(int productId);
    }
}
