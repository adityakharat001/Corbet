using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class Role
    {
        [DisplayName("Role Id")]
        public int RoleId { get; set; }
        [DisplayName("Role")]
        [Remote("IsRoleExist", "Role", HttpMethod = "GET", ErrorMessage = "Role Already Exist")]
        public string RoleName { get; set; }
    }
}
