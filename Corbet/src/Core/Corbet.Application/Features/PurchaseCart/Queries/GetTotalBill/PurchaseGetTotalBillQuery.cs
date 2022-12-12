using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Corbet.Application.Features.PurchaseCart.Queries.GetTotalBill
{

    public class PurchaseGetTotalBillQuery : IRequest<PurchaseGetTotalBillQueryVm>
    {
        public int UserId;
    }
}
