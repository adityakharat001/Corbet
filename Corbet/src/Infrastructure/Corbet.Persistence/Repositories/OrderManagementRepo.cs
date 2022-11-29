using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;

using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class OrderManagementRepository : BaseRepository<OrderManagement>, IOrderManagementRepo
    {
        public OrderManagementRepository(ApplicationDbContext dbContext, ILogger<OrderManagement> logger) : base(dbContext, logger)
        {

        }
    }
}
