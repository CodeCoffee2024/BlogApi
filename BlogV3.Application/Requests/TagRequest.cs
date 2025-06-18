using BlogV3.Application.Abstractions;
using BlogV3.Application.Commands.Tag.CreateTag;
using BlogV3.Application.Queries.Tag.GetTagList;

namespace BlogV3.Application.Requests
{
    public class TagRequest : PageRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Name { get; set; } = string.Empty;

        #endregion Properties

        #region Public Methods

        public CreateTagCommand SetAddCommand() =>
            new(PostId, Name);

        public GetTagListQuery ToQuery() => new(Search, OrderBy, PageNumber, PageSize);

        #endregion Public Methods
    }
}