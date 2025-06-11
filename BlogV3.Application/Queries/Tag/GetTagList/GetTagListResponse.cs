using BlogV3.Application.Dtos;

namespace BlogV3.Application.Queries.Tag.GetTagList
{
    public sealed class GetTagListResponse : List<TagDto>
    {
        #region Public Constructors

        public GetTagListResponse(IEnumerable<TagDto> tags) : base(tags)
        {
        }

        #endregion Public Constructors
    }
}