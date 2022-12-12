namespace Corbet.Application.Features.StockTypes.Queries.GetAllStockTypes
{
    public class GetAllStockTypesVm
    {
        public int StockTypeId { get; set; }
        public string StockTypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
