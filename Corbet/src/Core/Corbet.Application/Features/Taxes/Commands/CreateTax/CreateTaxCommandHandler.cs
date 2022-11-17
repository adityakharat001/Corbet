using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.CreateTax
{
    public class CreateTaxCommandHandler : IRequestHandler<CreateTaxCommand, CreateTaxDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTaxCommandHandler> _logger;
        private readonly ITaxRepository _taxRepository;
        public CreateTaxCommandHandler(IMapper mapper, ILogger<CreateTaxCommandHandler> logger, ITaxRepository taxRepository)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
            _logger = logger;
        }

        public async Task<CreateTaxDto> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("TaxCreate Handler Initiated");
            var TaxData = _mapper.Map<Tax>(request);
            var TaxDto = await _taxRepository.AddAsync(TaxData);
            var responseData = _mapper.Map<CreateTaxDto>(TaxDto);
            return responseData;
        }
    }
}
