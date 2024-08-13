#region Using

using CleanArchitecture.Management.Application.Contracts.Persistence;
using CleanArchitecture.Management.Domain.Core;
using CleanArchitecture.Management.Persistence.Context;

#endregion

namespace CleanArchitecture.Management.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(CleanArchitectureDbContext dbContext) : base(dbContext)
        {
        }

        /*public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            if (!includePassedEvents)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allCategories;
        }*/
    }
}
