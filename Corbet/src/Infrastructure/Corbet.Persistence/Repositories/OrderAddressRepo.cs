using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;

using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class OrderAddressRepo:BaseRepository<OrderAddress>,IOrderAddress
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public OrderAddressRepo(ApplicationDbContext dbContext, ILogger<OrderAddress> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
    
        }
        //public async Task<bool> AddingAddress(OrderAddress orderAddress)
        //{
        //  var check= await _dbContext.AddAsync(orderAddress);
        //    if (check!=null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
