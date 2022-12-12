namespace Corbet.Application.Features.StockTypes.Queries.GetStockTypeById
{
    public class GetStockTypeByIdVm
    {
        public int StockTypeId { get; set; }
        public string StockTypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
