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

namespace Corbet.Application.Features.Taxes.Queries.GetTaxById
{
    public class GetTaxByIdQueryHandler : IRequestHandler<GetTaxByIdQuery, Response<Tax>>
    {

        private readonly ITaxRepository _taxRepository;
        private readonly IMapper _mapper;

        public GetTaxByIdQueryHandler(ITaxRepository taxRepository, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        public async Task<Response<Tax>> Handle(GetTaxByIdQuery request, CancellationToken cancellationToken)
        {

            var tax = await _taxRepository.GetById(request.TaxId);
            if (tax.IsDeleted)
            {
                return null;
            }
            return new Response<Tax>(tax);
        }
    }
}
