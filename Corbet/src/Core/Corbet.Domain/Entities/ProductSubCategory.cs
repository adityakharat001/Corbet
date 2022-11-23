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
    public class ProductSubCategory:AuditableEntityModel
    {
        [Key]
        public int SubCategoryId { get; set; }
        public virtual int CategoryId {get;set;}
        [MaxLength(50)]
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public  virtual int TaxId { get; set; }
        public bool Status { get; set; }
     
         public bool IsDeleted { get; set; }
        [ForeignKey("TaxId")]
        public virtual Tax Taxes { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategories { get; set; }





    }
}
