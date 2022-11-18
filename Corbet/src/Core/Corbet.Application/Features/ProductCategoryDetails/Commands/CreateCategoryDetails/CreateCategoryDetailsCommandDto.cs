using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.CreateCategoryDetails
{
    public class CreateCategoryDetailsCommandDto
    {
        public int CategoryId { get; set; }
        public string CategoryDiscription { get; set; }
      
    }
}
