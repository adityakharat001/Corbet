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
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext dbContext, ILogger<Invoice> logger) : base(dbContext, logger)
        {
        }
    }
}
