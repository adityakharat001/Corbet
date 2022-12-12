using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Corbet.Ui.Models
{
    public class UpdateStockTypeModel
    {
        public string Id { get; set; }

        [Required]
        [Remote("CheckStockTypeExists", "StockType")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Special characters are not allowed.")]
        public string StockTypeName { get; set; }
    }
}
