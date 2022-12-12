using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Models
{
    public class ProductCategoryDdlModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [Remote("IsCategoryExist", "ProductCategory", HttpMethod = "GET", ErrorMessage = "Category Already Exist")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Category Name should contain only alphabates")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
