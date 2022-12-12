using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Command.UpdateSubCategory
{
    public class UpdateSubCategoryDto
    {
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public int TaxId { get; set; }
        public bool Status { get; set; }

    }
}
