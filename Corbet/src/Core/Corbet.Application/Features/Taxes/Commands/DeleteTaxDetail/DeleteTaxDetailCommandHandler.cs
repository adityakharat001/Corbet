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

namespace Corbet.Application.Features.Taxes.Commands.DeleteTaxDetail
{
    public class DeleteTaxDetailCommandHandler : IRequestHandler<DeleteTaxDetailCommand, Response<DeleteTaxDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteTaxDetailCommandHandler> _logger;
        private readonly ITaxDetailsRepository _taxDetailsRepository;

        public DeleteTaxDetailCommandHandler(IMapper mapper, ILogger<DeleteTaxDetailCommandHandler> logger, ITaxDetailsRepository taxDetailsRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _taxDetailsRepository = taxDetailsRepository;
        }

        public async Task<Response<DeleteTaxDetailDto>> Handle(DeleteTaxDetailCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete User Initiated");
            var taxDetailDto = await _taxDetailsRepository.RemoveTaxDetailsAsync(request.Id);
            _logger.LogInformation("Delete User Completed");

            if (taxDetailDto.Succeeded)
            {
                return new Response<DeleteTaxDetailDto>(taxDetailDto, "Success");
            }
            else
            {
                var res = new Response<DeleteTaxDetailDto>(taxDetailDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();


        }
    }
}
