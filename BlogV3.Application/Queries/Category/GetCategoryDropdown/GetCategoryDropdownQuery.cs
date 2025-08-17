using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Category.GetCategoryDropdown
{
    public class GetCategoryDropdownQuery : IRequest<Result<PageResult<CategoryFragment>>>
    {
        #region Public Constructors

        public GetCategoryDropdownQuery(string search, int pageNumber = 1)
        {
            Search = search;
            PageNumber = pageNumber;
        }

        #endregion Public Constructors

        #region Properties

        public string Search { get; set; }
        public int PageNumber { get; set; }

        #endregion Properties
    }
}