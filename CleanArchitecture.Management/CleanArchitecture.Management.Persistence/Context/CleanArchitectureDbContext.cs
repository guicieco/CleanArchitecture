#region Using

using CleanArchitecture.Management.Domain.Common;
using CleanArchitecture.Management.Domain.Core;
using CleanArchitecture.Management.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace CleanArchitecture.Management.Persistence.Context
{
    [ExcludeFromCodeCoverage]
    public class CleanArchitectureDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public CleanArchitectureDbContext(
            DbContextOptions<CleanArchitectureDbContext> options,
            IConfiguration configuration = null) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryEntity>(new CategoryMap().Configure);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "Guilherme :)";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "Guilherme :)";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
