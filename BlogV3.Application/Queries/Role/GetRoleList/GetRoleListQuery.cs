using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Role.GetRoleList
{
    public class GetRoleListQuery : PagedQuery, IRequest<Result<PageResult<GetRoleListResponse>>>
    {
        #region Public Constructors

        public GetRoleListQuery(
            string? search = null,
            string? orderBy = "Name",
            int pageNumber = 1,
            int pageSize = 1,
            string? status = ""
        )
        {
            Search = search;
            OrderBy = orderBy;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Status = status;
        }

        #endregion Public Constructors
    }
}