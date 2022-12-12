using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.DeleteTaxType
{
    public class DeleteTaxTypeCommandHandler : IRequestHandler<DeleteTaxTypeCommand, Response<DeleteTaxTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteTaxTypeCommandHandler> _logger;
        private readonly ITaxRepository _taxRepository;

        public DeleteTaxTypeCommandHandler(IMapper mapper, ILogger<DeleteTaxTypeCommandHandler> logger, ITaxRepository taxRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _taxRepository = taxRepository;
        }

        public async Task<Response<DeleteTaxTypeDto>> Handle(DeleteTaxTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete User Initiated");
            var taxDto = await _taxRepository.RemoveTaxTypeAsync(request.TaxId, request.DeletedBy);
            _logger.LogInformation("Delete User Completed");

            if (taxDto.Succeeded)
            {
                return new Response<DeleteTaxTypeDto>(taxDto, "Success");
            }
            else
            {
                var res = new Response<DeleteTaxTypeDto>(taxDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();


        }
    }
}
