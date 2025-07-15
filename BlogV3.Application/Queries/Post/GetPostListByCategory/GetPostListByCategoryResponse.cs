using System.Collections;
using BlogV3.Application.Dtos;

namespace BlogV3.Application.Queries.Post.GetPostListByCategory
{
    public sealed class GetPostListByCategoryResponse : IReadOnlyList<PostDto>
    {
        #region Fields

        private readonly IReadOnlyList<PostDto> _posts;

        #endregion Fields

        #region Public Constructors

        public GetPostListByCategoryResponse(IReadOnlyList<PostDto> posts)
        {
            _posts = posts;
        }

        #endregion Public Constructors

        #region Properties

        public int Count => _posts.Count;

        #endregion Properties

        #region Indexers

        public PostDto this[int index] => _posts[index];

        #endregion Indexers

        #region Public Methods

        public IEnumerator<PostDto> GetEnumerator() => _posts.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _posts.GetEnumerator();

        #endregion Public Methods
    }
}