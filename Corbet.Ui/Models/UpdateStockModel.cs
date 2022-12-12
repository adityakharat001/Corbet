using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class UpdateStockModel
    {
        //public int Id { get; set; }
        public string Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Entering quantity is a must.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than zero.")]
        public int Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select the type of stock.")]
        public int StockTypeId { get; set; }

        [Required]
        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }
        public bool IsDeleted { get; set; }
    }
}
