#region Using

using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace CleanArchitecture.Management.Persistence.Context
{
    [ExcludeFromCodeCoverage]
    public class CleanArchitectureDbContextFactory : DesignTimeDbContextFactoryBase<CleanArchitectureDbContext>
    {
        protected override CleanArchitectureDbContext CreateNewInstance(DbContextOptions<CleanArchitectureDbContext> options)
        {
            return new CleanArchitectureDbContext(options);
        }
    }
}