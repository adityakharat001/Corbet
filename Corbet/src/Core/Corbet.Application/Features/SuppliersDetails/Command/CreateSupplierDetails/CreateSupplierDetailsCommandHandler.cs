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

namespace Corbet.Application.Features.SuppliersDetails.Command.CreateSupplierDetails
{
    public class CreateSupplierDetailsCommandHandler : IRequestHandler<CreateSupplierDetailsCommand, Response<CreateSupplierDetailsCommandDto>>
    {
        private readonly ILogger<CreateSupplierDetailsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISupplierDetailsRepository _supplierDetailsRepository;
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplierDetailsCommandHandler(ILogger<CreateSupplierDetailsCommandHandler> logger, IMapper mapper, ISupplierDetailsRepository supplierDetailsRepository, ISupplierRepository supplierRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _supplierDetailsRepository = supplierDetailsRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<Response<CreateSupplierDetailsCommandDto>> Handle(CreateSupplierDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Adding Supplier Information initiated");

            var supplier = _mapper.Map<SupplierDetails>(request);
            var supplierData = await _supplierDetailsRepository.AddAsync(supplier);
            Supplier obj= _supplierDetailsRepository.SupplierDetailsAdding(supplier);
            if (obj != null)
            {
                var data =await _supplierRepository.AddAsync(obj);

            }
            var supplierDto = _mapper.Map<CreateSupplierDetailsCommandDto>(supplierData);
            return new Response<CreateSupplierDetailsCommandDto>(supplierDto);
            _logger.LogInformation("Adding Supplier Completed");
        }
    }

}
