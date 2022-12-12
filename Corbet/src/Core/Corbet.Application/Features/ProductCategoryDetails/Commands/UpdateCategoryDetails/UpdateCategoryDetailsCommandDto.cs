using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.UpdateCategoryDetails
{
    public class UpdateCategoryDetailsCommandDto
    {
        public int CategoryDetailsId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
    }
}
