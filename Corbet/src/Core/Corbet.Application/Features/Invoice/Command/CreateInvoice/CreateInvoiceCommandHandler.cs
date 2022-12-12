using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Invoice.Command.CreateInvoice
{
    public class CreateInvoiceCommandHandler:IRequestHandler<CreateInvoiceCommand, Response<CreateInvoiceCommandDto>>
    {
        private readonly ILogger<CreateInvoiceCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;

        public CreateInvoiceCommandHandler(ILogger<CreateInvoiceCommandHandler> logger, IMapper mapper, IInvoiceRepository invoiceRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Response<CreateInvoiceCommandDto>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("initiated");
            //var invoice=_mapper.Map<Domain.Entities.Invoice>(request.OrderCode, request.UserId);
            var dto = await _invoiceRepository.Addinvoice(request.UserId, request.OrderCode,request.PhoneNumber, request.InvoiceNumber);
           var mapInvoice= _mapper.Map<Domain.Entities.Invoice>(dto);
            var invoiceData = await _invoiceRepository.AddAsync(mapInvoice);
            var data = _mapper.Map<CreateInvoiceCommandDto>(invoiceData);
            _logger.LogInformation("completed");
            return new Response<CreateInvoiceCommandDto>(data);
        }
    }
}
