using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Exceptions;
using Corbet.Application.Features.Roles.Commands.UpdateRole;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler:IRequestHandler<UpdateSupplierCommand, Response<UpdateSupplierCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSupplierCommandHandler> _logger;
        private readonly ISupplierRepository _supplierRepository;
        public UpdateSupplierCommandHandler(IMapper mapper, ILogger<UpdateSupplierCommandHandler> logger, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _supplierRepository = supplierRepository;
        }

        public async Task<Response<UpdateSupplierCommandDto>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetById(request.Id);

            if(supplier== null)
            {
                throw new NotFoundException(nameof(Supplier), request.Id);
            }
            var supplierData=_mapper.Map(request,supplier);
            await _supplierRepository.UpdateAsync(supplierData);
            var supplierDto = _mapper.Map<UpdateSupplierCommandDto>(supplierData);         
            return new Response<UpdateSupplierCommandDto>(supplierDto);

        }
    }
}
