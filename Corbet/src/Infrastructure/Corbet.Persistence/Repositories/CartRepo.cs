﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.AddCart.Command.DeleteCart;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Application.Features.Roles.Commands.DeleteRole;
using Corbet.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class CartRepo: BaseRepository<AddToCart>, ICartRepo
    {
        private readonly ILogger _logger;
        public CartRepo(ApplicationDbContext dbContext, ILogger<AddToCart> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<DeleteCartCommandDto> RemoveCartAsync(int cartId)
        {
            DeleteCartCommandDto response = new DeleteCartCommandDto();
            var IsCartExist = await _dbContext.AddCarts.Where(x => x.CartId == cartId).FirstOrDefaultAsync();
            if (IsCartExist != null)
            {
              _dbContext.AddCarts.Remove(IsCartExist);
             
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


        public async Task<bool> IsCartExist(AddToCart addToCart)
        {
           var check=  _dbContext.AddCarts.Where(x => x.StockingId == addToCart.StockingId && x.UserId == addToCart.UserId).FirstOrDefault();
            if (check != null)
            {
                check.Quantity = check.Quantity + 1;
                
            
                _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<List<GetCartListVm>> GetAllCart(int userId)
        {


            var cart = (from c in _dbContext.AddCarts
                        join s in _dbContext.Stocks
                        on c.StockingId equals s.StockId
                        join p in _dbContext.Products
                        on s.ProductId equals p.ProductId
                        where (c.UserId == userId)
                        select new GetCartListVm
                        {
                            CartId = c.CartId,
                            //image = p.ImagePath,
                            Price = p.Price,
                            ProductName = p.ProductName,
                            Quantity = c.Quantity,
                      
                        }).ToList();
            _logger.LogInformation("GetAllCart");
            return cart;
        }



        public double GetProductPrice(int stockingid)
        {
            double pricenew;
            var price = (from s in _dbContext.Stocks
                         join p in _dbContext.Products
                         on s.StockId equals stockingid
                         select new
                         {
                             pricenew = p.Price
                         }).ToString;
            pricenew = Convert.ToDouble(price);
                         return pricenew;
        }

    }
}
