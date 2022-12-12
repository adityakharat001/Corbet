using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{

    public class OrderManagementRepo : BaseRepository<OrderManagement>, IOrderManagementRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public OrderManagementRepo(ApplicationDbContext dbContext, ILogger<OrderManagement> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }


        public  List<AddToCart> GetAllCart(int userId)
        {
           List<AddToCart>  addcart= _dbContext.AddCarts.Where(x => x.UserId == userId).ToList();
            return addcart;

        }

        
    }

}
