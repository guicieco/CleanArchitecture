#region Using

using CleanArchitecture.Management.Application.Contracts.Persistence;
using CleanArchitecture.Management.Domain.Core;
using CleanArchitecture.Management.Persistence.Context;
using Microsoft.EntityFrameworkCore;

#endregion

namespace CleanArchitecture.Management.Persistence.Repositories
{
    public class CategoryPagedRepository : ICategoryPagedRepository
    {
        protected readonly CleanArchitectureDbContext _dbContext;
        private readonly DbSet<CategoryEntity> _dataSet;

        public CategoryPagedRepository(CleanArchitectureDbContext dbContext)
        {
            _dbContext = dbContext;
            _dataSet = _dbContext.Set<CategoryEntity>();
        }

        public async Task<IEnumerable<CategoryEntity>> GetPaged(string name, int page, int size)
        {
            return await Select(name).Skip(page * size).Take(size).ToListAsync();
        }

        public async Task<int> GetCount(string name)
        {
            return await Select(name).CountAsync();
        }

        private IQueryable<CategoryEntity> Select(string name)
        {
            return _dataSet
                .Where(x => x.IsActive)
                .Where(x => string.IsNullOrEmpty(name) || EF.Functions.Like(x.Name.ToLower(), string.Concat("%", name.ToLower(), "%")))
                .AsNoTracking().AsQueryable();
        }
    }
}
