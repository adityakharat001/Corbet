using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.SuppliersDetails.Queries.GetSupplierDetailsById
{
    public class GetSupplierDetailsByIdQueryHandler:IRequestHandler<GetSupplierDetailsByIdQuery, SupplierDetails>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetSupplierDetailsByIdQueryHandler> _logger;
        private readonly ISupplierDetailsRepository _supplierDetailsRepository;

        public GetSupplierDetailsByIdQueryHandler(IMapper mapper, ILogger<GetSupplierDetailsByIdQueryHandler> logger, ISupplierDetailsRepository supplierDetailsRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _supplierDetailsRepository = supplierDetailsRepository;
        }

        public async Task<SupplierDetails> Handle(GetSupplierDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            SupplierDetails supplier = await _supplierDetailsRepository.GetById(request.SupplierId);
            return supplier;
        }
    }
}
