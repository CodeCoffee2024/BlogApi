using System.Collections;
using BlogV3.Application.Dtos;

namespace BlogV3.Application.Queries.Role.GetRoleList
{
    public sealed class GetRoleListResponse : IReadOnlyList<RoleDto>
    {
        #region Fields

        private readonly IReadOnlyList<RoleDto> _list;

        #endregion Fields

        #region Public Constructors

        public GetRoleListResponse(IReadOnlyList<RoleDto> modules)
        {
            _list = modules;
        }

        #endregion Public Constructors

        #region Properties

        public int Count => _list.Count;

        #endregion Properties

        #region Indexers

        public RoleDto this[int index] => _list[index];

        #endregion Indexers

        #region Public Methods

        public IEnumerator<RoleDto> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        #endregion Public Methods
    }
}