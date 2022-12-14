using Corbet.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class UnitMeasurement : AuditableEntityModel
    {
        [Required(ErrorMessage = "Enter Unit Id")]
        [DisplayName("Unit Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Unit Type")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Unit Type should not contain special characters")]
        [Remote("IsUnitMeasurementExists", "UnitMeasurement")]
        [DisplayName("Unit Type")]
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
    }
}
