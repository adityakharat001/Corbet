using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.OrderManagement.Queries;
using Corbet.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class OrderManagementRepo: BaseRepository<OrderManagement>, IOrderManagementRepo
    {
        public OrderManagementRepo(ApplicationDbContext dbContext, ILogger<OrderManagement> logger) : base(dbContext, logger)
        {

        }
        //public string SupplierName { get; set; }

        //public string DeliveryAddress { get; set; }
        //public DateOnly DeliveryDate { get; set; }
        //public string ProductName { get; set; }
        //public int Quantity { get; set; }
        //public int Price { get; set; }

        //public string CreditLimit { get; set; }
        //public string ThumbNail { get; set; }
        //public string POThumb { get; set; }
        //public string Description { get; set; }


        public async Task<List<GetOrderListVm>> GetAllOrder()
        {
            var orders = new List<GetOrderListVm>();
           

            var orderingdata = (from o in _dbContext.OrderManagements
                                join p in _dbContext.Products
                                on o.OrderProductId equals p.ProductId
                                join s in _dbContext.SupplierDetails
                                on o.SupplierId equals s.SupplierId
                                select new GetOrderListVm
                                {
                                    Price = p.Price,
                                    ThumbNail = o.MailThumb,
                                    POThumb = o.MailThumb,
                                    Description = o.Description,
                                    ProductName = p.ProductName,
                                    SupplierName=s.SupplierName,
                                    DeliveryAddress=s.BillingAddress,
                                   CreditLimit=s.CreditPeriod
                                }).ToList();
            return orderingdata;
        }
    
    }
}
