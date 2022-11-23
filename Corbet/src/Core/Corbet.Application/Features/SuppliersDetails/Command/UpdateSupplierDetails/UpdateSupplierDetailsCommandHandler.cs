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

namespace Corbet.Application.Features.SuppliersDetails.Command.UpdateSupplierDetails
{
    public class UpdateSupplierDetailsCommandHandler : IRequestHandler<UpdateSupplierDetailsCommand, Response<UpdateSupplierDetailsCommandDto>>
    {
        private readonly ILogger<UpdateSupplierDetailsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISupplierDetailsRepository _supplierRepository;

        public UpdateSupplierDetailsCommandHandler(ILogger<UpdateSupplierDetailsCommandHandler> logger, IMapper mapper, ISupplierDetailsRepository supplierRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        

        public async Task<Response<UpdateSupplierDetailsCommandDto>> Handle(UpdateSupplierDetailsCommand request, CancellationToken cancellationToken)
        {
            var supplierToUpdate = await _supplierRepository.GetById(request.Id);
            var supplierData=_mapper.Map(request, supplierToUpdate,typeof(UpdateSupplierDetailsCommand),typeof(SupplierDetails));
            await _supplierRepository.UpdateAsync(supplierToUpdate);
            var supplierDto=_mapper.Map<UpdateSupplierDetailsCommandDto>(supplierData);
            return new Response<UpdateSupplierDetailsCommandDto>(supplierDto);
        }
    }

}
