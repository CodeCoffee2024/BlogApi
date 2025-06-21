using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public record class Role : AuditableEntity
    {
        #region Private Constructors

        protected Role()
        { }

        #endregion Private Constructors

        #region Properties

        public string Name { get; private set; }
        public bool IsSystemGenerated { get; private set; } = false;

        public virtual ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
        public virtual ICollection<RolePermission> RolePermissions { get; private set; } = new List<RolePermission>();

        private Role(string name)
        {
            Name = name;
        }

        public static Role Create(string name, Guid createdById)
        {
            var entity = new Role(name);
            entity.SetCreated(createdById, DateTime.Now);
            return entity;
        }
        public void FlagAsSystemGenerated() => IsSystemGenerated = true;

        public void AddPermission(Permission permission)
        {
            RolePermissions.Add(new RolePermission { Role = this, Permission = permission });
        }

        #endregion Properties
    }
}