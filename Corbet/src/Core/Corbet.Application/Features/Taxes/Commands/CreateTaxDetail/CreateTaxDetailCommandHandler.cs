using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.CreateTaxDetail
{
    public class CreateTaxDetailCommandHandler : IRequestHandler<CreateTaxDetailCommand, Response<CreateTaxDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTaxDetailCommandHandler> _logger;
        private readonly ITaxDetailsRepository _taxDetailRepository;
        public CreateTaxDetailCommandHandler(IMapper mapper, ILogger<CreateTaxDetailCommandHandler> logger, ITaxDetailsRepository taxDetailRepository)
        {
            _mapper = mapper;
            _taxDetailRepository = taxDetailRepository;
            _logger = logger;
        }

        public async Task<Response<CreateTaxDetailDto>> Handle(CreateTaxDetailCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("TaxDetailCreate Handler Initiated");
            var TaxDetailData = _mapper.Map<TaxDetail>(request);
            var TaxDetailDto = await _taxDetailRepository.AddAsync(TaxDetailData);
            var responseData = _mapper.Map<CreateTaxDetailDto>(TaxDetailDto);
            return new Response<CreateTaxDetailDto>(responseData);
        }
    }
}

