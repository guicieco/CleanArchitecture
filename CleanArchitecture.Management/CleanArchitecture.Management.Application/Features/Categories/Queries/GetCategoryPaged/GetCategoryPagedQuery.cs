#region Using

using Ardalis.Result;
using MediatR;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryPaged
{
    public class GetCategoryPagedQuery : IRequest<Result<CategoryPagedVm>>
    {
        public string Name { get; set; } = string.Empty;
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
