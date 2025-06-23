using System.Collections;
using BlogV3.Application.Dtos;

namespace BlogV3.Application.Queries.User.GetUserList
{
    public sealed class GetUserListResponse : IReadOnlyList<UserDto>
    {
        #region Fields

        private readonly IReadOnlyList<UserDto> _list;

        #endregion Fields

        #region Public Constructors

        public GetUserListResponse(IReadOnlyList<UserDto> list)
        {
            _list = list;
        }

        #endregion Public Constructors

        #region Properties

        public int Count => _list.Count;

        #endregion Properties

        #region Indexers

        public UserDto this[int index] => _list[index];

        #endregion Indexers

        #region Public Methods

        public IEnumerator<UserDto> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        #endregion Public Methods
    }
}