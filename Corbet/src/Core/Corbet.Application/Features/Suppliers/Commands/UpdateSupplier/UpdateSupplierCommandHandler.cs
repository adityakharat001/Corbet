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

namespace Corbet.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Response<UpdateSupplierCommandDto>>
    {
        private readonly ILogger<UpdateSupplierCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public UpdateSupplierCommandHandler(ILogger<UpdateSupplierCommandHandler> logger, IMapper mapper, ISupplierRepository supplierRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        public async Task<Response<UpdateSupplierCommandDto>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplierToUpdate = await _supplierRepository.GetById(request.Id);
            var supplierData = _mapper.Map(request, supplierToUpdate, typeof(UpdateSupplierCommand), typeof(Supplier));
            await _supplierRepository.UpdateAsync(supplierToUpdate);
            var supplierDto = _mapper.Map<UpdateSupplierCommandDto>(supplierData);
            return new Response<UpdateSupplierCommandDto>(supplierDto);
        }
    }
}
