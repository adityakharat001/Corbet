using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Taxes.Commands.DeleteTaxDetail;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails
{
    public class DeleteCategoryDetailsCommandHandler:IRequestHandler<DeleteCategoryDetailsCommand, Response<DeleteCategoryDetailsCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCategoryDetailsCommandHandler> _logger;
        private readonly ICategoryDetailsRepo _categoryDetailsRepo;

        public DeleteCategoryDetailsCommandHandler(IMapper mapper, ILogger<DeleteCategoryDetailsCommandHandler> logger, ICategoryDetailsRepo categoryDetailsRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _categoryDetailsRepo = categoryDetailsRepo;
        }

        public async Task<Response<DeleteCategoryDetailsCommandDto>> Handle(DeleteCategoryDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("initiated");
            var categoryDeatils = await _categoryDetailsRepo.RemoveCategoryDetailsAsync(request.Id);
            _logger.LogInformation("Delete category deatils Completed");

            if (categoryDeatils.Succeeded)
            {
                return new Response<DeleteCategoryDetailsCommandDto>(categoryDeatils, "Success");
            }
            else
            {
                var res = new Response<DeleteCategoryDetailsCommandDto>(categoryDeatils, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();


        }

    }
    
}
