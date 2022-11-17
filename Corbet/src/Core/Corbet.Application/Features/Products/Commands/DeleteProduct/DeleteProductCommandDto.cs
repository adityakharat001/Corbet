using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandDto
    {
        public string Message { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public bool Succeeded { get; set; }
    }
}
