using BlogV3.Application.Dtos;

namespace BlogV3.Application.Queries.Dashboard.GetDashboardPostList
{
    public sealed class GetDashboardPostListResponse
    {
        #region Properties

        public IReadOnlyList<PostDto> Top4 { get; }
        public IReadOnlyList<PostDto> Highlights { get; }
        public IReadOnlyList<PostDto> Top2 { get; }
        public IReadOnlyList<PostDto> Latest { get; }

        #endregion Properties

        #region Constructor

        public GetDashboardPostListResponse(
            IEnumerable<PostDto> top4,
            IEnumerable<PostDto> highlights,
            IEnumerable<PostDto> top2,
            IEnumerable<PostDto> latest)
        {
            Top4 = top4?.ToList().AsReadOnly() ?? new List<PostDto>().AsReadOnly();
            Highlights = highlights?.ToList().AsReadOnly() ?? new List<PostDto>().AsReadOnly();
            Top2 = top2?.ToList().AsReadOnly() ?? new List<PostDto>().AsReadOnly();
            Latest = latest?.ToList().AsReadOnly() ?? new List<PostDto>().AsReadOnly();
        }

        #endregion Constructor
    }
}