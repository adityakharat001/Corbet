namespace Corbet.Application.Features.Stocks.Commands.DeleteStock
{
    public class DeleteStockDto
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int StockTypeId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }
}
