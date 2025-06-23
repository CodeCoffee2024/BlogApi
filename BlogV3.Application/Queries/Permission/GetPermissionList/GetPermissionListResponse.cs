using System.Collections;
using BlogV3.Application.Dtos;

namespace BlogV3.Application.Queries.Permission.GetPermissionList
{
    public sealed class GetPermissionListResponse : IReadOnlyList<PermissionDto>
    {
        #region Fields

        private readonly IReadOnlyList<PermissionDto> _list;

        #endregion Fields

        #region Public Constructors

        public GetPermissionListResponse(IReadOnlyList<PermissionDto> list)
        {
            _list = list;
        }

        #endregion Public Constructors

        #region Properties

        public int Count => _list.Count;

        #endregion Properties

        #region Indexers

        public PermissionDto this[int index] => _list[index];

        #endregion Indexers

        #region Public Methods

        public IEnumerator<PermissionDto> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        #endregion Public Methods
    }
}