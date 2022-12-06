using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.AddCart.Queries.GetTotalBill
{
    public class GetTotalBillQuery:IRequest<GetTotalBillQueryDto>
    {
        public int UserId;
    }
}
