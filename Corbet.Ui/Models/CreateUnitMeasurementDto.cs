using Corbet.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Corbet.Ui.Models
{
    public class CreateUnitMeasurementDto : AuditableEntity
    {

        [Required(ErrorMessage = "Enter Unit Type")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Unit Type should not contain special characters")]
        //[Remote("IsUnitExist", "UnitMeasurement", HttpMethod = "GET", ErrorMessage = "Unit Already Exist")]
        [DisplayName("Tax Type")]
        public string Type { get; set; }
    }
}
