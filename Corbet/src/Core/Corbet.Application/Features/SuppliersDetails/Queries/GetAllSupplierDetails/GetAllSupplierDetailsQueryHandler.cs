using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.SuppliersDetails.Queries.GetAllSupplierDetails
{
    public class GetAllSupplierDetailsQueryHandler:IRequestHandler<GetAllSupplierDetailsQuery, List<GetAllSupplierDetailsQueryVm>>
    {
        private readonly ILogger<GetAllSupplierDetailsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISupplierDetailsRepository _supplierDetailsRepository;

        public GetAllSupplierDetailsQueryHandler(ILogger<GetAllSupplierDetailsQueryHandler> logger, IMapper mapper, ISupplierDetailsRepository supplierDetailsRepository)
        {
            _logger= logger;
            _mapper= mapper;
            _supplierDetailsRepository= supplierDetailsRepository;

        }

        public async Task<List<GetAllSupplierDetailsQueryVm>> Handle(GetAllSupplierDetailsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get All initiated");
            var detailsList = await _supplierDetailsRepository.ListAllAsync();
            var detailsData = _mapper.Map<List<GetAllSupplierDetailsQueryVm>>(detailsList);
            _logger.LogInformation("Get all completed");
            return new List<GetAllSupplierDetailsQueryVm>(detailsData);
        }
    }
}
