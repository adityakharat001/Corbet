using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Models
{
    public class GetAllUnitMeasurementsViewModel
    {
        [Required(ErrorMessage = "Enter Unit Id")]
        [DisplayName("Unit Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Enter Unit Type")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Unit Type should not contain special characters")]
        [Remote("IsUnitMeasurementExists", "UnitMeasurement")]
        [DisplayName("Unit Type")]
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
    }
}
