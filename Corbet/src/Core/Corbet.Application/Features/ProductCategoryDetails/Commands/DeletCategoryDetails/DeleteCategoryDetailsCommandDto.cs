using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails
{
    public class DeleteCategoryDetailsCommandDto
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
