namespace Corbet.Application.Features.Stocks.Queries.GetAllStocks
{
    public class GetAllStocksVm
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int StockTypeId { get; set; }
        public string StockTypeName { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool IsDeleted { get; set; }
    }
}
