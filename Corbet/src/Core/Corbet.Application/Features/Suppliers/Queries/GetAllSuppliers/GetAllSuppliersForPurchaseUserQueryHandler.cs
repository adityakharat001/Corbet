using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersForPurchaseUserQueryHandler : IRequestHandler<GetAllSuppliersForPurchaseUserQuery, List<GetAllSuppliersQueryVm>>
    {
        private readonly ILogger<GetAllSuppliersForPurchaseUserQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public GetAllSuppliersForPurchaseUserQueryHandler(ILogger<GetAllSuppliersForPurchaseUserQueryHandler> logger, IMapper mapper, ISupplierRepository supplierRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<List<GetAllSuppliersQueryVm>> Handle(GetAllSuppliersForPurchaseUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Suppliers list Initiated");
            var supplierList = _supplierRepository.GetAllSuppliersForPurchaseUser();
            var supplierData = _mapper.Map<List<GetAllSuppliersQueryVm>>(supplierList);
            _logger.LogInformation("Suppliers list completed");
            return new List<GetAllSuppliersQueryVm>(supplierData);
        }
    }
}
