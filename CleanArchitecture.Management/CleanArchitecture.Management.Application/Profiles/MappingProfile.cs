#region Using

using AutoMapper;
using CleanArchitecture.Management.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArchitecture.Management.Domain.Core;

#endregion

namespace CleanArchitecture.Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<CategoryEntity, CategoryDto>();
            CreateMap<CategoryEntity, CategoryListVm>();
            CreateMap<CategoryEntity, CreateCategoryCommand>();
            CreateMap<CategoryEntity, CreateCategoryDto>();
        }
    }
}
