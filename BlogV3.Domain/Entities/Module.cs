using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public record class Module : AuditableEntity
    {
        public string Name { get; private set; }
        public bool IsSystemGenerated { get; private set; } = false;
        public virtual ICollection<Permission> Permissions { get; private set; } = new List<Permission>();
        protected Module() { }

        public Module(string name)
        {
            Name = name;
        }

        public static Module Create(string name, Guid createdById)
        {
            var module = new Module(name);
            module.SetCreated(createdById, DateTime.Now);
            return module;
        }
        public void FlagAsSystemGenerated() => IsSystemGenerated = true;
        public Module Update(string name, Guid updatedById, DateTime updatedOn)
        {
            Name = name;
            SetUpdated(updatedById, updatedOn);
            return this;
        }

        public Permission AddPermission(string permissionName)
        {
            var permission = new Permission(permissionName, this);
            Permissions.Add(permission);
            return permission;
        }
    }
}