using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Invoice.Queries.GetAllInvoice
{
    public class GetAllInvoiceQueryVm
    {
        public int Id { get; set; }
        public virtual string OrderCode { get; set; }
        public Guid InvoiceNumber { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        [MaxLength(250)]
        public string DelivaryAddress { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}
