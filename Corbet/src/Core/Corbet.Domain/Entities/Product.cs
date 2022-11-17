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
        public int ProductCategory { get; set; }
        public int ProductSubCategory { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }
        public int PrimarySupplierId { get; set; }
        public int SecondarySupplierId { get; set; }
        [MaxLength(1000)]
        public string? ImagePath { get; set; }
        public int TaxId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }
    }



}
