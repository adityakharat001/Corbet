using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace Corbet.Application.Features.Orders.GetOrdersForMonth
{
    public class GetOrdersForMonthQuery : IRequest<PagedResponse<IEnumerable<OrdersForMonthDto>>>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
