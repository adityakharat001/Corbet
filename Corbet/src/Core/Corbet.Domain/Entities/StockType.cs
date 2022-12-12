using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corbet.Domain.Common;

namespace Corbet.Domain.Entities
{
    public class StockType : AuditableEntityModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockTypeId { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string StockTypeName { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
