#region Using

using CleanArchitecture.Management.Domain.Core;

#endregion

namespace CleanArchitecture.Management.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<CategoryEntity>
    {
    }
}
