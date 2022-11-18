using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryList
{
    public class GetCategoryQueryVm
    {
        public int Id { get; set; }
        public  string CategoryName { get; set; }

        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public  string TaxName { get; set; }
        public bool Status { get; set; }







    }
}
    

