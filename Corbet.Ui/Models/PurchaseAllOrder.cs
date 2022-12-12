namespace Corbet.Ui.Models
{
    public class PurchaseAllOrder
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public string Status { get; set; }
        public string SupplierName { get; set; }
    }
}
