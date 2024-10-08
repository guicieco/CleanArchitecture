﻿#region Using

using Ardalis.Result;
using MediatR;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Result<CreateCategoryVm>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
