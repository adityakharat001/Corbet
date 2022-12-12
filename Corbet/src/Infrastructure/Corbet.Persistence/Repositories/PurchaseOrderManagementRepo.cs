using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.PurchaseCart.Queries.GetAllOrder;
using Corbet.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class PurchaseOrderManagementRepo : BaseRepository<PurchaseOrderManagement>, IPurchaseOrderManagement
    {
        //private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public PurchaseOrderManagementRepo(ApplicationDbContext dbContext, ILogger<PurchaseOrderManagement> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public List<PurchaseCart> GetAllCart(int userId)
        {

            List<PurchaseCart> addcart = _dbContext.PurchaseCarts.Where(x => x.UserId == userId).ToList();
            return addcart;


        }
        public async Task<List<GetAllOrderQueryVm>> GetAllOrder(int UserId)
        {
            var value = (from p in _dbContext.PurchaseOrderManagements
                         join s in _dbContext.Suppliers
                         on p.SupplierId equals s.SupplierId
                         where (p.UserId == UserId)
                         select new GetAllOrderQueryVm
                         {
                             SupplierName = s.SupplierName,
                             OrderCode = p.OrderCode,
                             Status = p.Status
                         }).ToList();
            return value;
        }

        public async Task<bool> UpdateStatus(int UserId, string status)
        {
            bool check = true;

            var order = await _dbContext.PurchaseOrderManagements.FirstOrDefaultAsync(u => u.UserId == UserId);
            if (order.Status == "Pending")
            {
                if (status == "accepted")
                {
                    order.Status = "Done";
                    int a = _dbContext.SaveChanges();
                    if (a > 0)
                    {
                        check = true;
                    }
                }
                if (status == "rejected")
                {
                    order.Status = "Failed";
                    int a = _dbContext.SaveChanges();
                    if (a > 0)
                    {
                        check = true;
                    }
                }
            }


            return check;

        }
    }
}
