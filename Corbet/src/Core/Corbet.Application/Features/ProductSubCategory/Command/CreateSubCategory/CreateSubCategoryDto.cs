using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Command.CreateSubCategory
{
    public class CreateSubCategoryDto
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public int TaxId { get; set; }
        public bool Status { get; set; }
    }
}
