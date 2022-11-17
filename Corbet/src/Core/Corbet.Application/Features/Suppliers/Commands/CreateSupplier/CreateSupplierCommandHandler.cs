using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Response<CreateSupplierCommandDto>>
    {
        private readonly ILogger<CreateSupplierCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;


        public CreateSupplierCommandHandler(ILogger<CreateSupplierCommandHandler> logger, IMapper mapper, ISupplierRepository supplierRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<Response<CreateSupplierCommandDto>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Adding Supplier Information initiated");

            var supplier = _mapper.Map<Supplier>(request);
            var supplierData = await _supplierRepository.AddAsync(supplier);
            var supplierDto = _mapper.Map<CreateSupplierCommandDto>(supplierData);
            return new Response<CreateSupplierCommandDto>(supplierDto);
            _logger.LogInformation("Adding Supplier Completed");
           
        }
    }
}
