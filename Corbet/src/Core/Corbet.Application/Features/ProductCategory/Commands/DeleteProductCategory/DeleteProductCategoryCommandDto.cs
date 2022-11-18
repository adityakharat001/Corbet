using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Commands.DeleteProductCategory
{
    public class DeleteProductCategoryCommandDto
    {
        public string Message { get; set; }
        public string CategoryName { get; set; }
        public bool Succeeded { get; set; }
    }
}
