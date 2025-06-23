using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Permission.GetPermissionList
{
    public class GetPermissionListQuery : PagedQuery, IRequest<Result<PageResult<GetPermissionListResponse>>>
    {
        #region Public Constructors

        public GetPermissionListQuery(
            string? search = null,
            string? orderBy = "Name",
            int pageNumber = 1,
            int pageSize = 1
        )
        {
            Search = search;
            OrderBy = orderBy;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        #endregion Public Constructors
    }
}