using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Queries.GetSupplierById
{
    internal class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, Supplier>
    {

        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierByIdQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<Supplier> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            Supplier user = await _supplierRepository.GetById(request.SupplierId);
            return user;
        }
    }
}
