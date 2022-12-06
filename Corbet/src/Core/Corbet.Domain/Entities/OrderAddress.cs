using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class OrderAddress
    {
        [Key]
        public int AddressId { get; set; }
       
        public int StateId { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        public int? ZipCode { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }


       
    }
}
