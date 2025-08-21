using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Post.GetPostListByCategory
{
    public class GetPostListByCategoryQuery : PagedQuery, IRequest<Result<PageResult<PostDto>>>
    {
        #region Public Constructors

        public GetPostListByCategoryQuery(
            string? search = null,
            string? category = null,
            int pageNumber = 1,
            int pageSize = 1,
            string? status = "activ"
        )
        {
            Search = search;
            OrderBy = "CreatedOn";
            Category = category ?? "";
            PageNumber = pageNumber;
            PageSize = pageSize;
            Status = status;
        }

        public string Category { get; set; }
        public string? Status { get; set; }

        #endregion Public Constructors
    }
}