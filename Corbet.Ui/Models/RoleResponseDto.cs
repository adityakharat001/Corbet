using Corbet.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class RoleResponseDto : AuditableEntity
    {
        [Required(ErrorMessage ="Role Name is required")]
        [DisplayName("Role Name")]
        [Remote("IsRoleExist", "Role", HttpMethod = "GET", ErrorMessage = "Role Already Exist")]
        [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = " Role Name must contain only alphabet")]
        public string RoleName { get; set; }
    }
}
