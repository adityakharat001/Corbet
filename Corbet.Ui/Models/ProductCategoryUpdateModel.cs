using Corbet.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Models
{
    public class ProductCategoryUpdateModel:AuditableEntityModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [Remote("IsCategoryExist", "ProductCategory", HttpMethod = "GET", ErrorMessage = "Category Already Exist")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Category Name should contain only alphabates")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Category Description")]
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
    }
}
