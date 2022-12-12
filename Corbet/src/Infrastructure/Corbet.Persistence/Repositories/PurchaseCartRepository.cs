using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.AddCart.Command.DeleteCart;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Application.Features.AddCart.Queries.GetProductSupplier;
using Corbet.Application.Features.PurchaseCart.Command;
using Corbet.Application.Features.PurchaseCart.Command.PurchaseDeleteCart;
using Corbet.Application.Features.PurchaseCart.Command.PurchaseRemoveAllCart;
using Corbet.Application.Features.PurchaseCart.Queries.GetAllCart;
using Corbet.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{

    public class PurchaseCartRepository : BaseRepository<PurchaseCart>, IPurchaseCartRepo
    {
        private readonly ILogger _logger;
        public PurchaseCartRepository(ApplicationDbContext dbContext, ILogger<PurchaseCart> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<bool> IsCartExist(PurchaseCart purchase)
        {


            var value = await _dbContext.PurchaseCarts.Where(x => x.StockId == purchase.StockId && x.UserId == purchase.UserId).FirstOrDefaultAsync();
            if (value != null)
            {
                value.Quantity = value.Quantity + 1;

                await _dbContext.SaveChangesAsync();
                return false;
            }
            else
            {

                return true;
            }


        }

        public async Task<PurchaseDeleteCartDto> RemovePurchaseCartAsync(int cartId)
        {
            PurchaseDeleteCartDto response = new PurchaseDeleteCartDto();
            var IsCartExist = await _dbContext.PurchaseCarts.Where(x => x.CartId == cartId).FirstOrDefaultAsync();
            if (IsCartExist != null)
            {
                _dbContext.PurchaseCarts.Remove(IsCartExist);

                await _dbContext.SaveChangesAsync();

                response.CartId = IsCartExist.CartId;
                response.Message = "Cart Deleted Successful";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Cart  Completed");
            }

            else
            {
                response.CartId = 0;
                response.Message = "Role with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Remove Cart Doesn't exist");
            }
        }

        public async Task<List<PurchaseGetAllCartQueryVm>> PurchaseGetAllCart(int userId)
        {


            var cart = (from c in _dbContext.PurchaseCarts
                        join s in _dbContext.Stocks
                        on c.StockId equals s.StockId
                        join p in _dbContext.Products
                        on s.ProductId equals p.ProductId
                        where (c.UserId == userId)
                        select new PurchaseGetAllCartQueryVm
                        {
                            UserId = userId,
                            ProductId = p.ProductId,
                            stockId = c.StockId,
                            CartId = c.CartId,
                            //image = p.ImagePath,
                            Price = p.Price,
                            ProductName = p.ProductName,
                            Quantity = c.Quantity,

                        }).ToList();
            _logger.LogInformation("GetAllCart");
            return cart;
        }


        public bool IncreaseCartitem(int cartId, int userId, int stockId, int productId, int Quantity)
        {


            var cartvalue = _dbContext.PurchaseCarts.Where(x => x.StockId == stockId && x.UserId == userId).FirstOrDefault();
            cartvalue.Quantity = cartvalue.Quantity + 1;
            _dbContext.SaveChangesAsync();
            return true;






        }


        public bool QuantityUpdate(int cartId, int userId, int stockId, int productId, int Quantity)
        {


            var cartvalue = _dbContext.PurchaseCarts.Where(x => x.StockId == stockId && x.UserId == userId).FirstOrDefault();
            cartvalue.Quantity = Quantity;
            _dbContext.SaveChangesAsync();
            return true;






        }

        //Decrease Cart

        public bool DecreaseCartitem(int cartId, int userId, int stockId, int productId, int Quantity)
        {

            if (Quantity != 1)
            {
                var cartvalue = _dbContext.PurchaseCarts.Where(x => x.StockId == stockId && x.UserId == userId).FirstOrDefault();
                cartvalue.Quantity = cartvalue.Quantity - 1;
                _dbContext.SaveChangesAsync();
                return true;
            }
            return false;





        }

        public async Task<PurchaseRemoveAllCartCommandDto> RemoveAllCartAsync(int userId)
        {
            PurchaseRemoveAllCartCommandDto response = new PurchaseRemoveAllCartCommandDto();
            List<PurchaseCart> IsCartExist = await _dbContext.PurchaseCarts.Where(x => x.UserId == userId).ToListAsync();
            foreach (var row in IsCartExist)
            {
                _dbContext.PurchaseCarts.Remove(row);
                await _dbContext.SaveChangesAsync();
            }



            response.UserId = userId;
            response.Message = "Cart Deleted Successful";
            response.Succeeded = true;
            return response;
            _logger.LogInformation("In Repository Cart  Completed");




        }



    }

}