using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;
using Corbet.Domain.Entities;

using MediatR;

namespace Corbet.Application.Features.Invoice.Command.CreateInvoice
{
    public class CreateInvoiceCommand:IRequest<Response<CreateInvoiceCommandDto>>
    {


        public int Id { get; set; }
        public  string OrderCode { get; set; }
        public Guid InvoiceNumber { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public  int Description { get; set; }
        [MaxLength(250)]
        public string DelivaryAddress { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }

       


    }
}
