using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.DeleteTaxType
{
    public class DeleteTaxTypeCommand: IRequest<Response<DeleteTaxTypeDto>>
    {
        public int TaxId { get; set; }
    }
}
