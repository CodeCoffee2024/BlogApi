using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public record class Tag : BaseEntity
    {
        public virtual Post? Post { get; private set; }
        public Guid PostId { get; private set; }
        public string Name { get; private set; } = string.Empty;

        protected Tag() { }
        private Tag(Guid postId, string name)
        {
            PostId = postId;
            Name = name;
        }

        public static Tag Create(Guid postId, string name)
        {
            Tag tag = new Tag(postId, name);
            return tag;
        }

        public Tag Update(string name)
        {
            Name = name;
            return this;
        }
    }
}