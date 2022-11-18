using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class GetSubCategoryVm
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public string TaxName { get; set; }
        public bool Status { get; set; }





    }
}
