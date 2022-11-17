using Corbet.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Corbet.Domain.Entities
{
    public class UserRole : AuditableEntityModel
    {

        [Key]
        public int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Users { get; set; }


        [ForeignKey("RoleId")]
        public virtual Role Roles { get; set; }


    }
}
