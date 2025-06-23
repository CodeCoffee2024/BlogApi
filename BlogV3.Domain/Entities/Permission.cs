using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public record class Permission : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public Guid? ModuleId { get; private set; } = null;
        public virtual Module? Module { get; private set; }
        public bool IsSystemGenerated { get; private set; } = false;

        public virtual ICollection<RolePermission> RolePermissions { get; private set; } = new List<RolePermission>();

        protected Permission() { }

        internal Permission(string name, Guid moduleId)
        {
            Name = name;
            ModuleId = moduleId;
        }

        public static Permission Create(string name, Guid moduleId)
        {
            var entity = new Permission(name, moduleId);
            return entity;
        }
        public Permission Update(string name)
        {
            Name = name;
            return this;
        }
        public void FlagAsSystemGenerated() => IsSystemGenerated = true;
    }
}