using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategory.Queries.GetAllProductCategories;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Invoice.Queries.GetAllInvoice
{
    public class GetAllInvoiceQueryHandler : IRequestHandler<GetAllInvoiceQuery, List<GetAllInvoiceQueryVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllInvoiceQueryHandler> _logger;
        private readonly IInvoiceRepository _invoiceRepository;

        public GetAllInvoiceQueryHandler(IMapper mapper, ILogger<GetAllInvoiceQueryHandler> logger, IInvoiceRepository invoiceRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<List<GetAllInvoiceQueryVm>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("All Invoices inintiated");

            var alltax = await _invoiceRepository.GetAllInvoices();

            var taxData = _mapper.Map<List<GetAllInvoiceQueryVm>>(alltax);

            _logger.LogInformation("Displayed all invoices successfully");

            return new List<GetAllInvoiceQueryVm>(taxData);
        }
    }
}
