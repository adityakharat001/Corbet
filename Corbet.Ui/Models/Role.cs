using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class Role
    {
        [DisplayName("Role Id")]
        public int RoleId { get; set; }
        [DisplayName("Role")]
        [Remote("IsRoleExist", "Role", HttpMethod = "GET", ErrorMessage = "Role Already Exist")]
        [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = " Role Name must contain only alphabet")]
        public string RoleName { get; set; }
    }
}
