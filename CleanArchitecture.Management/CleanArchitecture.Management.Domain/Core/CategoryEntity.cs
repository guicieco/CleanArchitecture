#region Using

using CleanArchitecture.Management.Domain.Common;

#endregion

namespace CleanArchitecture.Management.Domain.Core
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
