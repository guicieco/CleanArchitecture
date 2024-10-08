﻿#region Using

using Ardalis.Result;
using AutoMapper;
using CleanArchitecture.Management.Application.Contracts.Persistence;
using CleanArchitecture.Management.Domain.Core;
using MediatR;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CreateCategoryVm>>
    {
        private readonly IAsyncRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<CategoryEntity> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CreateCategoryVm>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                return await Task.FromResult(Result<CreateCategoryVm>.Invalid());
            }
            
            var category = new CategoryEntity() { Name = request.Name };
            category = await _categoryRepository.AddAsync(category);
            var categoryDto = _mapper.Map<CreateCategoryVm>(category);

            return await Task.FromResult(new Result<CreateCategoryVm>(categoryDto));
        }
    }
}
