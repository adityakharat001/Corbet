using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Queries.GetAllTaxes
{
    public class GetAllTaxesQueryHandler : IRequestHandler<GetAllTaxesQuery, List<GetAllTaxesVm>>
    {
        ITaxRepository _taxRepository;
        ILogger<GetAllTaxesQueryHandler> _logger;
        IMapper _mapper;

        public GetAllTaxesQueryHandler(ITaxRepository taxRepository, ILogger<GetAllTaxesQueryHandler> logger, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetAllTaxesVm>> Handle(GetAllTaxesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("All tax inintiated");

            var alltax = await _taxRepository.GetAllTaxes();

            var taxData = _mapper.Map<List<GetAllTaxesVm>>(alltax);

            _logger.LogInformation("Displayed all taxes successfully");

            return new List<GetAllTaxesVm>(taxData);
        }
    }
}
