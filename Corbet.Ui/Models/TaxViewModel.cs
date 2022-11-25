using Corbet.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Corbet.Ui.Models
{
    public class TaxViewModel : AuditableEntity
    {
        [Required(ErrorMessage = "Tax Id is required")]
       // [DisplayName("Tax Id")]
        public int TaxId { get; set; }
        //[Remote("IsTaxExist", "Tax", HttpMethod = "GET", ErrorMessage = "Tax Name Already Exist")]
        [Required(ErrorMessage = "Tax Type is required")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Tax Name should not contain special characters")]
        [DisplayName("Tax Type")]
        public string Name { get; set; }
    }
}
