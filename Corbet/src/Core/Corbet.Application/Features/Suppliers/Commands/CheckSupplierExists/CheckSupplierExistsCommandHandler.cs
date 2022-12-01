using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Suppliers.Commands.CheckSupplierExists
{
    public class CheckSupplierExistsCommandHandler : IRequestHandler<CheckSupplierExistsCommand, Response<bool>>
    {
        private readonly ILogger<CheckSupplierExistsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public CheckSupplierExistsCommandHandler(ILogger<CheckSupplierExistsCommandHandler> _logger, IMapper _mapper, ISupplierRepository _supplierRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._supplierRepository= _supplierRepository;
        }
        public async Task<Response<bool>> Handle(CheckSupplierExistsCommand request, CancellationToken cancellationToken)
        {
            var isSupplierExists = await _supplierRepository.CheckSupplierExists(request.SupplierName);
            return new Response<bool>() { Data = isSupplierExists, Succeeded = isSupplierExists };
        }
    }
}
