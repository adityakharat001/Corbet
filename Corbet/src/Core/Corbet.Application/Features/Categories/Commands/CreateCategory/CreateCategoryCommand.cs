﻿using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<Response<CreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
