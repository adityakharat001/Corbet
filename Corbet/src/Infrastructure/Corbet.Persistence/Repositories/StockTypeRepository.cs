using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class StockTypeRepository : BaseRepository<StockType>, IStockTypeRepository
    {
        public StockTypeRepository(ApplicationDbContext dbContext, ILogger<StockType> logger) : base(dbContext, logger)
        {
        }

        public async Task<bool> CheckStockTypeExists(string stockTypeName)
        {
            var stockTypeProduct = await _dbContext.StockTypes.FirstOrDefaultAsync(s => s.StockTypeName.Equals(stockTypeName));
            if (stockTypeProduct is not null)
            {
                return false;
            }
            else return true;
        }

        public async Task<StockType> GetByIdAsync(int id)
        {
            return await _dbContext.StockTypes.AsNoTracking().FirstOrDefaultAsync(st => st.StockTypeId == id);
        }

        public async Task<StockType> GetByTypeAsync(string stockTypeName)
        {
            return await _dbContext.StockTypes.FirstOrDefaultAsync(st => st.StockTypeName.Equals(stockTypeName));
        }

        public async Task<IReadOnlyList<StockType>> ListAllAsyncAddOn()
        {
            return await _dbContext.StockTypes.Where(st => st.IsDeleted == false).ToListAsync();
        }
    }
}
