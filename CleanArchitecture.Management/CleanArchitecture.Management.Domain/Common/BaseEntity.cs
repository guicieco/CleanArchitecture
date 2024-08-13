#region Using

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace CleanArchitecture.Management.Domain.Common
{
    [ExcludeFromCodeCoverage]
    public class BaseEntity : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BaseEntityAsInteger : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
