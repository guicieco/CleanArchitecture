namespace CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryPaged
{
    public class CategoryPagedVm
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public IEnumerable<CategoryForPagedDto>? List { get; set; }
    }
}
