using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class RoleUpdateDto
    {
        public string Id { get; set; }
        public int RoleId { get; set; }
        [DisplayName("Role")]
        [Required(ErrorMessage = "Role Is required")]
        [RegularExpression(@"^([A-Za-z])+( [A-Za-z]+)*$", ErrorMessage = " Role Name must contain only alphabet")]
        public string RoleName { get; set; }
    }
}
