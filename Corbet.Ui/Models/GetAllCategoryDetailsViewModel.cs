namespace Corbet.Ui.Models
{
    public class GetAllCategoryDetailsViewModel
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
