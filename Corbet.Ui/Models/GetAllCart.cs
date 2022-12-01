using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class GetAllCart
    {
        public int CartId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int stockId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
