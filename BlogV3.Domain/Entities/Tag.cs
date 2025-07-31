using BlogV3.Domain.Abstractions;

namespace BlogV3.Domain.Entities
{
    public class Tag : BaseEntity
    {
        #region Protected Constructors

        protected Tag()
        { }

        #endregion Protected Constructors

        #region Private Constructors

        private Tag(Guid postId, string name)
        {
            PostId = postId;
            Name = name;
        }

        #endregion Private Constructors

        #region Properties

        public virtual Post? Post { get; private set; }
        public Guid PostId { get; private set; }
        public string Name { get; private set; } = string.Empty;

        #endregion Properties

        #region Public Methods

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

        #endregion Public Methods
    }
}