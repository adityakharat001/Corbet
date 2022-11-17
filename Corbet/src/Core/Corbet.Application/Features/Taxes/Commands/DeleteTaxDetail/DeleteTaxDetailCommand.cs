using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.DeleteTaxDetail
{
    public class DeleteTaxDetailCommand: IRequest<Response<DeleteTaxDetailDto>>
    {
        public int Id { get; set; }
    }
}
