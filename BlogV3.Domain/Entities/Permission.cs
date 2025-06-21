using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public record class Permission : BaseEntity
    {
        public string Name { get; private set; }
        public Guid? ModuleId { get; private set; }
        public virtual Module Module { get; private set; }
        public bool IsSystemGenerated { get; private set; } = false;

        public virtual ICollection<RolePermission> RolePermissions { get; private set; } = new List<RolePermission>();

        protected Permission() { }

        internal Permission(string name, Module module)
        {
            Name = name;
            Module = module;
            ModuleId = module.Id;
        }
        public void FlagAsSystemGenerated() => IsSystemGenerated = true;
    }
}