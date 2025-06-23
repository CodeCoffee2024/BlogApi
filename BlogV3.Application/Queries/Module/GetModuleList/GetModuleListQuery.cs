using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Module.GetModuleList
{
    public class GetModuleListQuery : PagedQuery, IRequest<Result<PageResult<GetModuleListResponse>>>
    {
        #region Public Constructors

        public GetModuleListQuery(
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