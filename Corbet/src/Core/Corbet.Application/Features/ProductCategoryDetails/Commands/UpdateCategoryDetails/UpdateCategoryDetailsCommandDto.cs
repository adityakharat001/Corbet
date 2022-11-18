using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.UpdateCategoryDetails
{
    public class UpdateCategoryDetailsCommandDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDiscription { get; set; }
    }
}
