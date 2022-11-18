using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Please select Category name")]
       
        public int CategoryId { get; set; }
        [DisplayName("Category Description")]
        [Required(ErrorMessage = "Please add Product Category description")]
        public string CategoryDiscription { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
