using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Invoice.Command.CreateInvoice;
using Corbet.Application.Features.Invoice.Queries.GetAllInvoice;
using Corbet.Application.Features.ProductCategoryDetails.Queries.GetAllCategoryDetails;
using Corbet.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using MimeKit.Encodings;

using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Corbet.Persistence.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext dbContext, ILogger<Invoice> logger) : base(dbContext, logger)
        {


        }
        //get all Invoices
        public async Task<List<Invoice>> GetAllInvoices()
        {
            //List<Invoice> invoice = await _dbContext.Invoices.GetAllInvoice();
            var value = (from o in _dbContext.OrderManagements
                        join I in _dbContext.Invoices
                        on o.OrderCode equals I.OrderCode
                        //join sup in _dbContext.Suppliers
                        //on o.SupplierId equals sup.SupplierId
                        select new Invoice
                        {
                            Id = I.Id,
                            InvoiceNumber = I.InvoiceNumber,
                            OrderCode = I.OrderCode,
                            UserId = I.UserId,
                            DelivaryAddress = I.DelivaryAddress,
                           // PhoneNumber = I.PhoneNumber,
                            Description = I.Description,
                            TotalPrice = I.TotalPrice,
                            Status= I.Status
                        }).ToList();
            return value;
        }

        //add invoice
        public async Task<CreateInvoiceCommand> Addinvoice(int UserId, string OrderCode,string Phone,Guid InvoiceNumber)
        {
            CreateInvoiceCommand createinvoicecommand = new CreateInvoiceCommand();
            var invoicedata = await _dbContext.OrderManagements.Where(x => x.OrderCode == OrderCode).FirstOrDefaultAsync();

            if (invoicedata != null)
            {
                createinvoicecommand.InvoiceNumber = InvoiceNumber;
                createinvoicecommand.OrderCode = invoicedata.OrderCode;
                createinvoicecommand.DelivaryAddress = invoicedata.Address;
                createinvoicecommand.UserId = invoicedata.UserId;
                createinvoicecommand.PhoneNumber = Phone;
                return createinvoicecommand;
            }
            return null;
        }

    }
}
