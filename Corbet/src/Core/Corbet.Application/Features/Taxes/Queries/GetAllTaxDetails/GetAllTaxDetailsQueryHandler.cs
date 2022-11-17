using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails
{
    public class GetAllTaxDetailsQueryHandler : IRequestHandler<GetAllTaxDetailsQuery, List<GetTaxDetailListVm>>
    {
        ITaxDetailsRepository _taxRepository;
        ILogger<GetAllTaxDetailsQueryHandler> _logger;
        IMapper _mapper;
        public GetAllTaxDetailsQueryHandler(ITaxDetailsRepository taxRepository, ILogger<GetAllTaxDetailsQueryHandler> logger, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<List<GetTaxDetailListVm>> Handle(GetAllTaxDetailsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Tax Details Initiated");
            var taxData = await _taxRepository.GetAllTaxDetails();

            var taxList = _mapper.Map<List<GetTaxDetailListVm>>(taxData);

            _logger.LogInformation("Tax details display successfully");
            return new List<GetTaxDetailListVm>(taxList);
        }
    }
}
