﻿using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Corbet.Domain.Common;

namespace Corbet.Ui.Models
{
    public class CategoryDetailsUpdateModel:AuditableEntityModel
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage ="Please Enter Category Name")]
        public int CategoryId { get; set; }
        [DisplayName("Category Description")]
        [Required(ErrorMessage = "Please Add Product Category description")]
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
