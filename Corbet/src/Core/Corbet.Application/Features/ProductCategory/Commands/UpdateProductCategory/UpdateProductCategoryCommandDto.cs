﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommandDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}