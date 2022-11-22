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
        [MaxLength(30)]
        public string SupplierName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(250)]
        public string BillingAddress { get; set; }
        [MaxLength(100)]
        public string SupplierType { get; set; }
        public long CreditLimit { get; set; }
        public DateTime CreditPeriod { get; set; } = DateTime.Now;
        public string? DocumentPath { get; set; } = "rinku.pdf";
        public bool IsActive { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public bool IsPaymentDone { get; set; } = false;

    }
}
