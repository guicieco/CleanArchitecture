#region Using

using CleanArchitecture.Management.Application.Contracts.Persistence;
using CleanArchitecture.Management.Domain.Core;
using CleanArchitecture.Management.Persistence.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Xml.Linq;

#endregion

namespace CleanArchitecture.Management.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(CleanArchitectureDbContext dbContext) : base(dbContext)
        {
        }
    }
}
