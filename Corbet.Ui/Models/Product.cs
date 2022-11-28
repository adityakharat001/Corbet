namespace Corbet.Ui.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubCategory { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public string PrimarySupplier { get; set; }
        public string SecondarySupplier { get; set; }
        public string? ImagePath { get; set; }
        public string Tax { get; set; }
        public double TaxApplicable { get; set; }
        public bool IsActive { get; set; }
        
    }
}
