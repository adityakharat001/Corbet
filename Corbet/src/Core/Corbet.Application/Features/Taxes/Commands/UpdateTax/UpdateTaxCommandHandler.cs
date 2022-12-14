using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Exceptions;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.UpdateTax
{
    public class UpdateTaxCommandHandler : IRequestHandler<UpdateTaxCommand, Response<UpdateTaxDto>>
    {
        private readonly ILogger<UpdateTaxCommandHandler> _logger;
        private readonly ITaxRepository _taxRepository;
        private readonly IMapper _mapper;
        public UpdateTaxCommandHandler(ILogger<UpdateTaxCommandHandler> logger, ITaxRepository taxRepository, IMapper mapper)
        {
            _logger = logger;
            _taxRepository = taxRepository;
            _mapper = mapper;
        }
        public async Task<Response<UpdateTaxDto>> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update tax initiated");
            var tax = await _taxRepository.GetById(request.TaxId);
            if (tax == null)
            {
                throw new NotFoundException(nameof(Tax), request.TaxId);
            }
            var taxData = _mapper.Map(request, tax);
            await _taxRepository.UpdateAsync(taxData);
            var taxDto = _mapper.Map<UpdateTaxDto>(taxData);
            _logger.LogInformation("Update tax completed");
            return new Response<UpdateTaxDto>(taxDto);
        }
    }
}
