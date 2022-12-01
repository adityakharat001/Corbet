using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Domain.Common;

namespace Corbet.Domain.Entities
{
    public class Invoice : AuditableEntityModel
    {
        [Key]
        public int Id { get; set; }
        public  string OrderCode { get; set; }
        public Guid InvoiceNumber { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber {get;set;}
        public string Description { get; set; }
        [MaxLength(250)]
        public string DelivaryAddress { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.Now;
        public DateTime ExpectedDate { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
  
        //[ForeignKey("OrderCode")]
        //public virtual OrderManagement OrderManagements { get; set; }   

    }
}
