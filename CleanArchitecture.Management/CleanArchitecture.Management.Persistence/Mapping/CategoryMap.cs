#region Using

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using CleanArchitecture.Management.Domain.Core;

#endregion

namespace CleanArchitecture.Management.Persistence.Mapping
{
    [ExcludeFromCodeCoverage]
    public class CategoryMap : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(250);
            builder.Property(a => a.IsActive).HasDefaultValue(true);
            builder.Property(a => a.CreatedBy).HasMaxLength(250);
            builder.Property(a => a.LastModifiedBy).HasMaxLength(250);
            builder.Property(a => a.CreatedDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(a => a.LastModifiedDate);
        }
    }
}
