using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class SubCategoryAddView
    {

        [Required(ErrorMessage = "Select a Category Name")]

        public  int CategoryId { get; set; }
        [Required(ErrorMessage = "SubCategory Name is required")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "SubCategory Name should not contain special characters")]
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Select a Tax Type")]
        public  int TaxId { get; set; }
        [Required(ErrorMessage = "Select a Status")]
        public bool Status { get; set; }
        
     public int CreatedBy { get; set; }
      


    }
}
