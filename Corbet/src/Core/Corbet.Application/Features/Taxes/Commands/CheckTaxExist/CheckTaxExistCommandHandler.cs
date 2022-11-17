using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.CheckTaxExist
{
    public class CheckTaxExistCommandHandler : IRequestHandler<CheckTaxExistCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;
        private readonly ILogger<CheckTaxExistCommandHandler> _logger;

        public CheckTaxExistCommandHandler(ILogger<CheckTaxExistCommandHandler> logger, IMapper mapper, ITaxRepository taxRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _taxRepository = taxRepository;
        }
        public async Task<bool> Handle(CheckTaxExistCommand request, CancellationToken cancellationToken)
        {
            var checkTaxAvailabilityStatus = await _taxRepository.CheckTaxExists(request.Name);
            return (checkTaxAvailabilityStatus) ? true : false;
        }
    }
}
