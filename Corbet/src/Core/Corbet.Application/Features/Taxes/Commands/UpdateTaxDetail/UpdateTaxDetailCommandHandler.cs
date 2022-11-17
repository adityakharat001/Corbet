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

namespace Corbet.Application.Features.Taxes.Commands.UpdateTaxDetail
{
    public class UpdateTaxDetailCommandHandler : IRequestHandler<UpdateTaxDetailCommand, Response<UpdateTaxDetailDto>>
    {
        private readonly ILogger<UpdateTaxDetailCommandHandler> _logger;
        private readonly ITaxDetailsRepository _taxDetailRepository;
        private readonly IMapper _mapper;

        public UpdateTaxDetailCommandHandler(ILogger<UpdateTaxDetailCommandHandler> logger, ITaxDetailsRepository taxManagementRepository, IMapper mapper)
        {
            _logger = logger;
            _taxDetailRepository = taxManagementRepository;
            _mapper = mapper;
        }
        public async Task<Response<UpdateTaxDetailDto>> Handle(UpdateTaxDetailCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update taxDetail initiated");
            var tax = await _taxDetailRepository.GetById(request.Id);
            if (tax == null)
            {
                throw new NotFoundException(nameof(TaxDetail), request.Id);
            }

            var taxData = _mapper.Map(request, tax);
            await _taxDetailRepository.UpdateAsync(taxData);
            var taxDto = _mapper.Map<UpdateTaxDetailDto>(taxData);
            _logger.LogInformation("Update taxDetail completed");
            return new Response<UpdateTaxDetailDto>(taxDto);
        }
    }
}
