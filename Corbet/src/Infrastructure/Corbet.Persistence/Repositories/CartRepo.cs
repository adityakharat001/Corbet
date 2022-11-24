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
    public class CartRepo: BaseRepository<AddToCart>, ICartRepo
    {

        private readonly ILogger _logger;
        public CartRepo(ApplicationDbContext dbContext, ILogger<AddToCart> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

    }
}
