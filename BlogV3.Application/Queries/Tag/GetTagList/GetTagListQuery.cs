using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Tag.GetTagList
{
    public class GetTagListQuery : PagedQuery, IRequest<Result<PageResult<GetTagListResponse>>>
    {
        #region Public Constructors

        public GetTagListQuery(string? search = null, string? orderBy = "Name", int pageNumber = 1, int pageSize = 1)
        {
            Search = search;
            OrderBy = orderBy;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        #endregion Public Constructors
    }
}