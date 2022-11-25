﻿using Corbet.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class ProductCategoryUpdateModel:AuditableEntity
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Category Name is required")]
        [RegularExpression(@"^([A-Za-z])+( [A-Za-z]+)*$", ErrorMessage = " Category Name must contain only alphabet")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
