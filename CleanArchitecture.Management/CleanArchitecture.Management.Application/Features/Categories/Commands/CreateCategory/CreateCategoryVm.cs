namespace CleanArchitecture.Management.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
