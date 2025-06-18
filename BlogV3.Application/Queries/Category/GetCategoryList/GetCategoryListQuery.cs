using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Category.GetCategoryList
{
    public class GetCategoryListQuery : PagedQuery, IRequest<Result<PageResult<CategoryDto>>>
    {
        #region Public Constructors

        public GetCategoryListQuery(string? search = null, string? orderBy = "Name", int pageNumber = 1, int pageSize = 1, string? status = "")
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