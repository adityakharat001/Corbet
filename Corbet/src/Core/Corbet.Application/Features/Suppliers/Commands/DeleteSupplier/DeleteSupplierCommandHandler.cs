using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;

using MediatR;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Response<DeleteSupplierCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteSupplierCommandHandler> _logger;
        private readonly ISupplierRepository _supplierRepository;
        public DeleteSupplierCommandHandler(IMapper mapper, ILogger<DeleteSupplierCommandHandler> logger, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _supplierRepository = supplierRepository;
        }

        public async Task<Response<DeleteSupplierCommandDto>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Delete Supplier Initiated");
            var supplierDto = await _supplierRepository.RemoveSupplierAsync(request.SupplierId);
            _logger.LogInformation("Delete Supplier Completed");
            if (supplierDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<DeleteSupplierCommandDto>(supplierDto, "Success");
            }
            else
            {
                var res = new Response<DeleteSupplierCommandDto>(supplierDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();
        }
    }
}
