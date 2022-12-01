using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.Invoice.Command.CreateInvoice;
using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IInvoiceRepository:IAsyncRepository<Invoice>
    {
        public Task<CreateInvoiceCommand> Addinvoice(int UserId, string OrderCode,string Phone,Guid InvoiceNumber);

        public Task<List<Invoice>> GetAllInvoices();
    }
}
