#region Using

using Ardalis.Result;
using MediatR;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery : IRequest<Result<CategoryDetailVm>>
    {
        public Guid Id { get; set; }
    }
}
