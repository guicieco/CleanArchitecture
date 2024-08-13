#region Using

using Ardalis.Result;
using MediatR;

#endregion

namespace CleanArchitecture.Management.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
