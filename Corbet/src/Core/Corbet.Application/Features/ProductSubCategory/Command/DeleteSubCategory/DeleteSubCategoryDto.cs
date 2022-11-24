using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Command.DeleteSubCategory
{
 
    public class DeleteSubCategoryDto
    {

        public string Message { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool Succeeded { get; set; }
    }
}
