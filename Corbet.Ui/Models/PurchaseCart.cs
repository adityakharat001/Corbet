using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class PurchaseCart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }

        public int StockId { get; set; }

        public int Quantity { get; set; }
    }
}
