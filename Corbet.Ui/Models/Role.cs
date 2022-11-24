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
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = " Role Name Must Contain Only Alphabet")]
        [Remote("IsRoleExist", "Role", HttpMethod = "GET", ErrorMessage = "Role Already Exist")]
        public string RoleName { get; set; }
    }
}
