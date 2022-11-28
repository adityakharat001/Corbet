using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IStockTypeRepository : IAsyncRepository<StockType>
    {
        Task<bool> CheckStockTypeExists(string stockTypeName);
        Task<StockType> GetByIdAsync(int id);
        Task<StockType> GetByTypeAsync(string stockTypeName);
    }
}
