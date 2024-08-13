#region Using

using AutoMapper;
using CleanArchitecture.Management.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Management.Application.Features.Categories.Commands.UpdateCategory;
using CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryDetail;
using CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryPaged;
using CleanArchitecture.Management.Domain.Core;

#endregion

namespace CleanArchitecture.Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryEntity, CategoryDetailVm>();
            CreateMap<CategoryEntity, CategoryListVm>();
            CreateMap<CategoryEntity, CreateCategoryCommand>();
            CreateMap<CategoryEntity, CreateCategoryVm>();
            
            CreateMap<UpdateCategoryCommand, CategoryEntity>()
                .ReverseMap();

            CreateMap<CategoryForPagedDto, CategoryEntity>()
                .ReverseMap();
        }
    }
}
