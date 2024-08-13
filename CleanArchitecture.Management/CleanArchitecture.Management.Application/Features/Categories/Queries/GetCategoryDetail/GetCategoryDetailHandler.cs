#region Using

using Ardalis.Result;
using AutoMapper;
using CleanArchitecture.Management.Application.Contracts.Persistence;
using CleanArchitecture.Management.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Management.Domain.Core;
using MediatR;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailHandler : IRequestHandler<GetCategoryDetailQuery, Result<CategoryDetailVm>>
    {
        private readonly IAsyncRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryDetailHandler(
            IMapper mapper,
            IAsyncRepository<CategoryEntity> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CategoryDetailVm>> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return await Task.FromResult(Result<CategoryDetailVm>.Invalid());
            }

            var categoryDetailVm = _mapper.Map<CategoryDetailVm>(category);
            return await Task.FromResult(new Result<CategoryDetailVm>(categoryDetailVm));
        }
    }
}