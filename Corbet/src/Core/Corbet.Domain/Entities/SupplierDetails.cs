using Corbet.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class SupplierDetails : AuditableEntityModel
    {
        [Key]
        public int SupplierId { get; set; }
        [MaxLength(150)]
        //company name=supplierName
        public string SupplierName { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(300)]
        public string BillingAddress { get; set; }
        [MaxLength(200)]
        public string SupplierType { get; set; }
        public long CreditLimit { get; set; }
        public DateTime CreditPeriod { get; set; } = DateTime.Now;
        public string? DocumentPath { get; set; } = "rinku.pdf"; 
        public bool IsDeleted { get; set; }
    }
}
