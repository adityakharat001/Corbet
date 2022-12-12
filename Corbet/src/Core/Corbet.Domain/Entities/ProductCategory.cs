using Corbet.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class ProductCategory:AuditableEntityModel
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(100)]
        public string CategoryName { get; set; }
        [MaxLength(2000)]
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
