#region Using

using CleanArchitecture.Management.Domain.Core;

#endregion

namespace CleanArchitecture.Management.Application.Contracts.Persistence
{
    public interface ICategoryPagedRepository
    {
        Task<IEnumerable<CategoryEntity>> GetPaged(string name, int page, int size);
        Task<int> GetCount(string name);
    }
}
