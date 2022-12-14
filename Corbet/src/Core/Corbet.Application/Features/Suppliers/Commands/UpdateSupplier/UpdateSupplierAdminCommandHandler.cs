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
    public class UpdateSupplierAdminCommandHandler : IRequestHandler<UpdateSupplierAdminCommand, Response<UpdateSupplierAdminCommandDto>>
    {
        private readonly ILogger<UpdateSupplierAdminCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public UpdateSupplierAdminCommandHandler(ILogger<UpdateSupplierAdminCommandHandler> logger, IMapper mapper, ISupplierRepository supplierRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        public async Task<Response<UpdateSupplierAdminCommandDto>> Handle(UpdateSupplierAdminCommand request, CancellationToken cancellationToken)
        {
            var supplierToUpdate = await _supplierRepository.GetById(request.SupplierId);
            var supplierData = _mapper.Map(request, supplierToUpdate, typeof(UpdateSupplierAdminCommand), typeof(Supplier));
            await _supplierRepository.UpdateAsync(supplierToUpdate);
            var supplierDto = _mapper.Map<UpdateSupplierAdminCommandDto>(supplierData);
            return new Response<UpdateSupplierAdminCommandDto>(supplierDto);
        }
    }
}
