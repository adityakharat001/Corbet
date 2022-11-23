namespace Corbet.Ui.Models
{
    public class GetCategoryDetailView
    {
       
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
