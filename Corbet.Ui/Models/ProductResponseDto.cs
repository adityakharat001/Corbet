using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Corbet.Domain.Common;

namespace Corbet.Ui.Models
{
    public class ProductResponseDto:AuditableEntityModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Product Category")]
        public int CategoryId { get; set; }
        [DisplayName("Product Subcategory")]
        public int SubCategoryId { get; set; }
        [DisplayName("Unit Type")]
        public int UnitId { get; set; }
        public double Price { get; set; }
        [DisplayName("Primary Supplier")]
        public int PrimarySupplierId { get; set; }
        [DisplayName("Secondary Supplier")]
        //[Compare("PrimarySupplierId",ErrorMessage ="")]
        public int SecondarySupplierId { get; set; }
        [DisplayName("Choose Image")]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
        [DisplayName("Tax Type")]
        public int TaxId { get; set; }
        [DisplayName("Status")]
        public bool IsActive { get; set; }

    }
}
