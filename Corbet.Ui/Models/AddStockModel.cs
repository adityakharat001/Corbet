using Microsoft.AspNetCore.Mvc;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Corbet.Ui.Models
{
    public class AddStockModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please select a product.")]
        [Remote("CheckProductExistsInStockList", "Stock")]
        [DisplayName("Enter Product Name")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Entering quantity is a must.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than zero.")]
        [DisplayName("Enter Quantity")]
        public int Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select the type of stock.")]
        [DisplayName("Enter Stock Type")]
        public int StockTypeId { get; set; }

        [Required]
        public DateTime TimeIn { get; set; } = DateTime.Now;

        public DateTime? TimeOut { get; set; }
        public bool IsDeleted { get; set; }
    }
}
