namespace Corbet.Ui.Models
{
    public class GetSubCategoryViewModel
    {
        public string SubCategoryId { get; set; }
        public string CategoryName { get; set; }

        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public string TaxName { get; set; }
        public bool Status { get; set; }
    }
}
