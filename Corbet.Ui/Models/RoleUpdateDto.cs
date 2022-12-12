using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Corbet.Domain.Common;

namespace Corbet.Ui.Models
{
    public class RoleUpdateDto: AuditableEntityModel
    {
        public int Id { get; set; }
        [DisplayName("Role")]
        [Required(ErrorMessage = "Role Is required")]
        public string RoleName { get; set; }
    }
}
