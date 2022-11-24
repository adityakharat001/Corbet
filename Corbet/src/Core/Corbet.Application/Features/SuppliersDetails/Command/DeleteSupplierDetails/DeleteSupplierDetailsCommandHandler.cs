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
    public class DeleteSupplierDetailsCommandHandler : IRequestHandler<DeleteSupplierDetailsCommand, Response<DeleteSupplierDetailsCommandDto>>
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

        public async Task<Response<DeleteSupplierDetailsCommandDto>> Handle(DeleteSupplierDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("initiated");
            var supplierDeatils = await _supplierRepository.RemoveSupplierDetailsAsync(request.SupplierId);
            _logger.LogInformation("Delete category deatils Completed");

            if (supplierDeatils.Succeeded)
            {
                return new Response<DeleteSupplierDetailsCommandDto>(supplierDeatils, "Success");
            }
            else
            {
                var res = new Response<DeleteSupplierDetailsCommandDto>(supplierDeatils, "Failed");
                res.Succeeded = false;
                return res;
            }

            throw new NotImplementedException();

        }
        }

    }

