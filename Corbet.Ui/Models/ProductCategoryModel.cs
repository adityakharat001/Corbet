using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class ProductCategoryModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Category Name should contain only alphabates")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
