#region Using

using Ardalis.Result;
using AutoMapper;
using CleanArchitecture.Management.Application.Contracts.Persistence;
using MediatR;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryPaged
{
    public class GetCategoryPagedHandler : IRequestHandler<GetCategoryPagedQuery, Result<CategoryPagedVm>>
    {
        private readonly ICategoryPagedRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryPagedHandler(ICategoryPagedRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CategoryPagedVm>> Handle(GetCategoryPagedQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetPaged(request.Name, request.Page, request.Size);
            var categories = _mapper.Map<IEnumerable<CategoryForPagedDto>>(list);

            var count = await _repository.GetCount(request.Name);
            return await Task.FromResult(new Result<CategoryPagedVm>(new CategoryPagedVm() { Count = count, List = categories, Page = request.Page, Size = request.Size }));
        }
    }
}
