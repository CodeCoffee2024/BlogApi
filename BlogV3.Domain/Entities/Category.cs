using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public record class Category : AuditableEntity
    {
        #region Properties

        public string Name { get; private set; }
        public string Status { get; private set; }
        public virtual IEnumerable<Post>? Posts { get; }

        #endregion Properties

        #region Private Constructors

        protected Category() { }
        private Category(string name, string status)
        {
            Name = name;
            Status = status;
        }

        public static Category Create(string name, string status, DateTime createdOn, Guid createdById)
        {
            Category category = new Category(name, status);
            category.SetCreated(createdById, createdOn);
            return category;
        }

        public Category Update(string name, string status, DateTime updatedOn, Guid updatedById)
        {
            Name = name;
            Status = status;
            SetUpdated(updatedById, updatedOn);
            return this;
        }

        #endregion Private Constructors
    }
}