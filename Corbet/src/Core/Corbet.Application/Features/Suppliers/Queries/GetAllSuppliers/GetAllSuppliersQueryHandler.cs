using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, List<GetAllSuppliersQueryVm>>
    {
        private readonly ILogger<GetAllSuppliersQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly ISupplierRepository _supplierRepository;

    public GetAllSuppliersQueryHandler(ILogger<GetAllSuppliersQueryHandler> logger, IMapper mapper, ISupplierRepository supplierRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _supplierRepository = supplierRepository;
    }

    public async Task<List<GetAllSuppliersQueryVm>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Suppliers list Initiated");
        var supplierList = await _supplierRepository.ListAllAsync();
        var supplierData = _mapper.Map<List<GetAllSuppliersQueryVm>>(supplierList);
        _logger.LogInformation("Suppliers list completed");
        return new List<GetAllSuppliersQueryVm>(supplierData);
    }
}
}
