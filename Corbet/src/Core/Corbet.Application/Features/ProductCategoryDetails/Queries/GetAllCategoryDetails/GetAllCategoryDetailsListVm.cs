using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Queries.GetAllCategoryDetails
{
    public class GetAllCategoryDetailsListVm
    {
        
        public int Id { get; set; }
        public string CategoryName { get; set; }
  
        public string CategoryDiscription { get; set; }
        public bool Status { get; set; }

        public bool IsDeleted { get; set; }
    }
}
