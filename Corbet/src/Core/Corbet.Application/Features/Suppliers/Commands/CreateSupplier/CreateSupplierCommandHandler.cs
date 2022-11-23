using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler:IRequestHandler<CreateSupplierCommand, Response<CreateSuplierCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSupplierCommandHandler> _logger;
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplierCommandHandler(IMapper mapper, ILogger<CreateSupplierCommandHandler> logger, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _supplierRepository = supplierRepository;
        }

        public async Task<Response<CreateSuplierCommandDto>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Supplier>(request);
            var supplierData = await _supplierRepository.AddAsync(supplier);
            
            var supplierDto = _mapper.Map<CreateSuplierCommandDto>(supplierData);
            return new Response<CreateSuplierCommandDto>(supplierDto);
        }
    }
}
