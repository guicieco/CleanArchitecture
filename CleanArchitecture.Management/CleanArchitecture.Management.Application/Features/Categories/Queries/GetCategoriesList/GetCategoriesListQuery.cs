#region Using

using MediatR;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
