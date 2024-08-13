#region Using

using Ardalis.Result;
using AutoMapper;
using CleanArchitecture.Management.Application.Contracts.Persistence;
using CleanArchitecture.Management.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Management.Domain.Core;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
    {
        private readonly IAsyncRepository<CategoryEntity> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(
            IMapper mapper,
            IAsyncRepository<CategoryEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _repository.GetByIdAsync(request.Id);
            if (entityToUpdate == null)
            {
                return await Task.FromResult(Result.Invalid());
            }

            var validator = new UpdateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                return await Task.FromResult(Result.Invalid());

            //entityToUpdate = _mapper.Map<CategoryEntity>(request);

            await _repository.UpdateAsync(entityToUpdate);
            return await Task.FromResult(Result.Success());
        }
    }
}