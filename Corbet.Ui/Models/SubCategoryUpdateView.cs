﻿using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class SubCategoryUpdateView
    {
        public string? Id { get; set; }

        public int SubCategoryId { get; set; }
        [Required(ErrorMessage = "Select a Category Name")]

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "SubCategory Name is required")]
        [RegularExpression(@"^([A-Za-z])+( [A-Za-z]+)*$", ErrorMessage = " Sub Category Name must contain only alphabet")]


        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Select a Tax Type")]
        public int TaxId { get; set; }
        [Required(ErrorMessage = "Select a Status")]
        public bool Status { get; set; }

        public int CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }

    }
}
