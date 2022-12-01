using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Product Category")]
        public string ProductCategory { get; set; }
        [DisplayName("Product Subcategory")]
        public string ProductSubCategory { get; set; }
        [DisplayName("Unit")]
        public string Unit { get; set; }
        [DisplayName("Price")]
        public double Price { get; set; }
        [DisplayName("Primary Supplier")]
        public string PrimarySupplier { get; set; }
        [DisplayName("Secondary Supplier")]
        public string SecondarySupplier { get; set; }
        public string? ImagePath { get; set; }
        [DisplayName("Tax Type")]
        public string Tax { get; set; }
        [DisplayName("Tax Applicable")]
        public double TaxApplicable { get; set; }
        [DisplayName("Status")]
        public bool IsActive { get; set; }
        
    }
}
