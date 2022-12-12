using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.Stocks.Commands.AddStock
{
    public class AddStockCommand : IRequest<Response<AddStockDto>>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int StockTypeId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public int? CreatedBy { get; set; }

    }
}
