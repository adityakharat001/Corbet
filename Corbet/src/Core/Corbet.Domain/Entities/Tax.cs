using Corbet.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class Tax: AuditableEntityModel
    {
        [Key]
        public int TaxId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
