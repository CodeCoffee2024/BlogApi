using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public record class Post : AuditableEntity
    {
        #region Properties

        public Guid CategoryId { get; private set; }
        public virtual Category? Category { get; init; }
        public string Status { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<Tag>? Tags { get; set; }

        protected Post() { }

        #endregion Properties

        #region Private Constructors

        private Post(Guid categoryId, string status, string title, string description)
        {
            CategoryId = categoryId;
            Status = status;
            Title = title;
            Description = description;
        }

        public static Post Create(Guid categoryId, string status, string title, string description, DateTime createdOn, Guid createdById)
        {
            Post post = new Post(categoryId, status, title, description);
            post.SetCreated(createdById, createdOn);
            return post;
        }

        public Post Update(Guid categoryId, string status, string title, string description, DateTime updatedOn, Guid updatedById)
        {
            CategoryId = categoryId;
            Status = status;
            Title = title;
            Description = description;
            SetUpdated(updatedById, updatedOn);
            return this;
        }

        #endregion Private Constructors
    }
}