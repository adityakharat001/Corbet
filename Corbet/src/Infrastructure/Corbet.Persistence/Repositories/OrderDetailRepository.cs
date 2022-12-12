using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;
using Corbet.Persistence.Repositories;
using Corbet.Persistence;

using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>,IOrderDetailRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public OrderDetailRepository(ApplicationDbContext dbContext, ILogger<OrderDetail> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}