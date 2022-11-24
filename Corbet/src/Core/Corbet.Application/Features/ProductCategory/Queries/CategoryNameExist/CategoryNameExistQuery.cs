using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.ProductCategory.Queries.CategoryNameExist
{
    public class CategoryNameExistQuery:IRequest<bool>
    {
        public string CategoryName { get; set; }
        public CategoryNameExistQuery(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
