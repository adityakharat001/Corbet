using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandDto
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int TaxId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
