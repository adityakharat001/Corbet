using Corbet.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class ProductCategoryDetail:AuditableEntityModel
    {
        [Key]
        public int Id { get; set; }
        public virtual int CategoryId { get; set; }
        [MaxLength(2000)]
        public string CategoryDiscription { get; set; }
        public bool Status { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory productCategories { get; set; }
        public bool IsDeleted { get; set; }
    }
}
