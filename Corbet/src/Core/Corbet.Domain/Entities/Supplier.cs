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
        public int Id { get; set; }
        public int uniqueId { get; set; }
        [MaxLength(100)]
        public string SupplierName { get; set; }
        public long CreaditLimit { get; set; }
        public bool PaymentStatus { get; set; } = true;



    }
}
