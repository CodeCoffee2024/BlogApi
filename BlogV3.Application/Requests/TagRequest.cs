using BlogV3.Application.Commands.Tag.CreateTag;
using BlogV3.Application.Queries.Tag.GetTagList;

namespace BlogV3.Application.Requests
{
    public class TagRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Name { get; set; } = string.Empty;

        #endregion Properties

        #region Public Methods

        public CreateTagCommand SetAddCommand() =>
            new(PostId, Name);

        public GetTagListQuery ToQuery() => new(Name);

        #endregion Public Methods
    }
}