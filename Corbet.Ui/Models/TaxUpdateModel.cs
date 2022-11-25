using Corbet.Domain.Common;

using Microsoft.AspNetCore.Mvc;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class TaxUpdateModel :AuditableEntityModel
    {
        [Required(ErrorMessage = "Tax Id is required")]
        [DisplayName("Tax Id")]
        public int Id { get; set; }
        [Remote("IsTaxExist", "Tax", HttpMethod = "GET", ErrorMessage = "Tax Name Already Exist")]
        [Required(ErrorMessage = "Tax Name is required")]
        [RegularExpression(@"^([A-Za-z])+( [A-Za-z]+)*$", ErrorMessage = " Tax Name must contain only alphabet")]
        [DisplayName("Tax Name")]
        public string Name { get; set; }
    }
}
