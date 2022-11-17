using Corbet.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class RoleResponseDto : AuditableEntity
    {
        [Required(ErrorMessage ="Role Name is required")]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
    }
}
