using Corbet.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class UnitMeasurement : AuditableEntity
    {
        [Required(ErrorMessage = "Enter Unit Id")]
        [DisplayName("Unit Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Unit Type")]
        [RegularExpression(@"^([A-Za-z])+( [A-Za-z]+)*$", ErrorMessage = " Role Name must contain only alphabet")]
        [Remote("IsUnitMeasurementExists", "UnitMeasurement")]
        [DisplayName("Unit Type")]
        public string Type { get; set; }
    }
}
