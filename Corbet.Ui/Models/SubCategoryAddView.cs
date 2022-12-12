using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class SubCategoryAddView
    {

        [Required(ErrorMessage = "Select a Category Name")]
        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "SubCategory Name is required")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "SubCategory Name should not contain special characters")]
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Select a Tax Type")]
        [DisplayName("Tax Type")]
        public int TaxId { get; set; }
        [Required(ErrorMessage = "Select a Status")]
        public bool Status { get; set; }

        public int CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }



    }
}
