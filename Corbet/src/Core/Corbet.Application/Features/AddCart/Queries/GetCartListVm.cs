using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Domain.Entities;

namespace Corbet.Application.Features.AddCart.Queries
{
    public class GetCartListVm
    {
     
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string image { get; set; }
        public string Description
        {
            get; set;

        }
    }
}
