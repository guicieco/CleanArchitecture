#region Using

using Ardalis.Result;
using AutoMapper;
using CleanArchitecture.Management.Application.Contracts.Persistence;
using CleanArchitecture.Management.Domain.Core;
using MediatR;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
    {
        private readonly IAsyncRepository<CategoryEntity> _repository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IMapper mapper, IAsyncRepository<CategoryEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _repository.GetByIdAsync(request.Id);

            if (entityToDelete == null)
            {
                return await Task.FromResult(Result.Invalid());
            }

            await _repository.DeleteAsync(entityToDelete);
            return await Task.FromResult(Result.Success());
        }
    }
}
