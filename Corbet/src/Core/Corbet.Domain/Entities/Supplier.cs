using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Domain.Common;

namespace Corbet.Domain.Entities
{
    public class Supplier:AuditableEntityModel
    {
        [Key]
        public int SupplierId { get; set; }
        [MaxLength(30)]
        public string SupplierName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(150)]
        public string BillingAddress { get; set; }
        [MaxLength(50)]
        public string SupplierType { get; set; }
        public long CreditLimit { get; set; }
        public DateTime CreditPeriod { get; set; }
        public string? DocumentPath { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public bool IsPaymentDone { get; set; } = false;



    }
}
