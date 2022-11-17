using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Queries.GetTaxDetailsById
{
    public class GetTaxDetailsByIdQueryHandler : IRequestHandler<GetTaxDetailsByIdQuery, Response<TaxDetail>>
    {

        private readonly ITaxDetailsRepository _taxDetailsRepository;
        private readonly IMapper _mapper;

        public GetTaxDetailsByIdQueryHandler(ITaxDetailsRepository taxDetailsRepository, IMapper mapper)
        {
            _taxDetailsRepository = taxDetailsRepository;
            _mapper = mapper;
        }

        public async Task<Response<TaxDetail>> Handle(GetTaxDetailsByIdQuery request, CancellationToken cancellationToken)
        {

            var taxDetails = await _taxDetailsRepository.GetById(request.Id);
            return new Response<TaxDetail>(taxDetails);
        }
    }
}
