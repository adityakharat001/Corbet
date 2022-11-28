using System;
using System.Collections.Generic;
using System.Security.Cryptography;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class OrderManagementRepo : BaseRepository<OrderManagement>, IOrderManagementRepo
    {
        public OrderManagementRepo(ApplicationDbContext dbContext, ILogger<OrderManagement> logger) : base(dbContext, logger)
        {

        }

        public async Task<List<GetCartListVm>> GetAllCart(int userId)
        {
           

            var cart= (from c in _dbContext.AddCarts
                         join p in _dbContext.Products
                         on c.ProductId equals p.ProductId
                         join subcategory in _dbContext.ProductSubCategories
                         on p.SubCategoryId equals subcategory.SubCategoryId
                         where (c.UserId == userId)
                         select new GetCartListVm
                         {
                             CartId=c.CartId,
                             image=p.ImagePath,
                             Price = p.Price,
                             ProductName = p.ProductName,
                             Quantity = c.Quantity,
                             Description = subcategory.Description
                         }).ToList();

            return cart;
        }

    }
}
