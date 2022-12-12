using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.PurchaseCart.Queries.GetAllCart;
using Corbet.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext dbContext, ILogger<Stock> logger) : base(dbContext, logger)
        {
        }

        public async Task<bool> CheckProductExistsInStockList(int productId)
        {
            var stockProduct = await _dbContext.Stocks.FirstOrDefaultAsync(s => s.ProductId == productId);
            if (stockProduct is not null)
            {
                return false;
            }
            else return true;
        }

        public async Task<Stock> GetByIdAsync(int stockId)
        {
            return await _dbContext.Stocks.AsNoTracking().FirstOrDefaultAsync(s => s.StockId == stockId);
        }

        public async Task<Stock> GetByProductIdAsync(int productId)
        {
            return await _dbContext.Stocks.FirstOrDefaultAsync(s => s.ProductId == productId);
        }


        public async Task<bool> UpdateStockQuantity(List<PurchaseGetAllCartQueryVm> cart)
        {
            bool check = true;
            foreach (var item in cart)
            {
                var stockProduct = await _dbContext.Stocks.FirstOrDefaultAsync(s => s.StockId == item.stockId);

                stockProduct.Quantity = stockProduct.Quantity + item.Quantity;
                int a = _dbContext.SaveChanges();
                if (a > 0)
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
            }
            return check;
        }
    }
}
