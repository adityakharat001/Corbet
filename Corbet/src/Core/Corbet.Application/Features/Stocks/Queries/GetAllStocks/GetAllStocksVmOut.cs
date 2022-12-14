namespace Corbet.Application.Features.Stocks.Queries.GetAllStocks
{
    public class GetAllStocksVmOut
    {
        public int StockId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string StockTypeName { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool IsDeleted { get; set; }
    }
}
