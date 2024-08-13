namespace CleanArchitecture.Management.Application.Features.Categories.Queries.GetCategoryPaged
{
    public class CategoryForPagedDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
