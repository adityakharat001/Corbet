using Corbet.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Corbet.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
