using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public record class Post : AuditableEntity
    {
        #region Properties

        public Guid CategoryId { get; private set; }
        public virtual Category? Category { get; init; }
        public string Status { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public virtual ICollection<Tag>? Tags { get; set; }
        public string ImgPath { get; private set; } = string.Empty;

        protected Post() { }

        #endregion Properties

        #region Private Constructors

        private Post(Guid categoryId, string status, string title, string description, string imgPath)
        {
            ImgPath = imgPath;
            CategoryId = categoryId;
            Status = status;
            Title = title;
            Description = description;
        }

        public static Post Create(Guid categoryId, string status, string title, string description, DateTime createdOn, Guid createdById, string imgPath = "")
        {
            Post post = new Post(categoryId, status, title, description, imgPath);
            post.SetCreated(createdById, createdOn);
            return post;
        }

        public Post Update(Guid categoryId, string title, string description, DateTime updatedOn, Guid updatedById)
        {
            CategoryId = categoryId;
            Title = title;
            Description = description;
            SetUpdated(updatedById, updatedOn);
            return this;
        }

        #endregion Private Constructors
    }
}