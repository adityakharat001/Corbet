using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
