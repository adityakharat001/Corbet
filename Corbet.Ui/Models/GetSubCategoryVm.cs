using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class GetSubCategoryVm
    {
        public int SubCategoryId { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Subcategory Name")]
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        [DisplayName("Tax")]
        public string TaxName { get; set; }
        public bool Status { get; set; }





    }
}
