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
    public class Product: AuditableEntityModel
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(30)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ProductCode { get; set; }
        [MaxLength(300)]
        public string ProductName { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int SubCategoryId { get; set; }
        public virtual int UnitId { get; set; }
        public double Price { get; set; }
        public  virtual int PrimarySupplierId { get; set; }
        public virtual int SecondarySupplierId { get; set; }
        [MaxLength(1000)]
        public string? ImagePath { get; set; }
        public virtual int TaxId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }

        [ForeignKey("UnitId")]
        public virtual UnitMeasurement UnitMeasurements { get; set; }

        [ForeignKey("PrimarySupplierId")]
        public virtual Supplier PrimarySupplier { get; set; }
        
        [ForeignKey("SecondarySupplierId")]
        public virtual Supplier SecondarySupplier { get; set; }
        
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategories { get; set; }
        
        [ForeignKey("SubCategoryId")]
        public virtual ProductSubCategory ProductSubCategories { get; set; }
        
        [ForeignKey("TaxId")]
        public virtual Tax Taxes { get; set; }
    }



}
