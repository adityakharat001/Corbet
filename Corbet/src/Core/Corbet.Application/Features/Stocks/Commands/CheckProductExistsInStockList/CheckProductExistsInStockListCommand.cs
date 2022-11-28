using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.Products.Commands.CheckProductExistsInStockList
{
    public class CheckProductExistsInStockListCommand : IRequest<Response<bool>>
    {
        public int ProductId { get; set; }
    }
}
