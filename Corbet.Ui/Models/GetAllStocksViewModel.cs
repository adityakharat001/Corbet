namespace Corbet.Ui.Models
{
    public class GetAllStocksViewModel
    {
        public string StockId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string StockTypeName { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool IsDeleted { get; set; }
    }
}
