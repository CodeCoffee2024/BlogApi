using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Post.GetPostList
{
    public class GetPostListQuery : PagedQuery, IRequest<Result<PageResult<GetPostListResponse>>>
    {
        #region Public Constructors

        public GetPostListQuery(
            string? search = null,
            string? orderBy = "Name",
            int pageNumber = 1,
            int pageSize = 1,
            string? status = "activ"
        )
        {
            Search = search;
            OrderBy = orderBy;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Status = status;
        }

        public string? Status { get; set; }

        #endregion Public Constructors
    }
}