using System.ComponentModel;

using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Models
{
    public class GetAllRolesViewModel
    {
        [DisplayName("Role Id")]
        public string RoleId { get; set; }
        [DisplayName("Role")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = " Role Name Must Contain Only Alphabet")]
        [Remote("IsRoleExist", "Role", HttpMethod = "GET", ErrorMessage = "Role Already Exist")]
        public string RoleName { get; set; }
    }
}
