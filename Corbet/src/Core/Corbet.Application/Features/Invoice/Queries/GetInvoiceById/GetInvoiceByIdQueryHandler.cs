using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Suppliers.Queries.GetSupplierById;
using Corbet.Domain.Entities;

using MediatR;

namespace Corbet.Application.Features.Invoice.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Domain.Entities.Invoice>
    {

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Invoice> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Invoice invoice = await _invoiceRepository.GetById(request.Id);
            return invoice;
        }

    }
}
