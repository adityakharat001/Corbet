using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.SuppliersDetails.Command.DeleteSupplierDetails
{
    public class DeleteSupplierDetailsCommandHandler : IRequestHandler<DeleteCategoryDetailsCommand, Response<DeleteCategoryDetailsCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteSupplierDetailsCommandHandler> _logger;
        private readonly ISupplierDetailsRepository _supplierRepository;
        public DeleteSupplierDetailsCommandHandler(IMapper mapper, ILogger<DeleteSupplierDetailsCommandHandler> logger, ISupplierDetailsRepository supplierRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _supplierRepository = supplierRepository;
        }

        public async Task<Response<DeleteCategoryDetailsCommandDto>> Handle(DeleteCategoryDetailsCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Delete Supplier Initiated");
            var supplierDto = await _supplierRepository.RemoveSupplierDetailsAsync(request.Id);
            _logger.LogInformation("Delete Supplier Completed");
            if (supplierDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<DeleteCategoryDetailsCommandDto>(supplierDto, "Success");
            }
            else
            {
                var res = new Response<DeleteCategoryDetailsCommandDto>(supplierDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();
        }
    }
    
}
