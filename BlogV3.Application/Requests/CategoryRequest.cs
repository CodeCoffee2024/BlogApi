using BlogV3.Application.Abstractions;
using BlogV3.Application.Commands.Category.CreateCategory;
using BlogV3.Application.Queries.Category.GetCategoryDropdown;
using BlogV3.Application.Queries.Category.GetCategoryList;

namespace BlogV3.Application.Requests
{
    public class CategoryRequest : PageRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;

        #endregion Properties

        #region Public Methods

        public CreateCategoryCommand SetAddCommand(Guid UserId) =>
            new(UserId, Name);

        public GetCategoryListQuery ToQuery() => new(Search, OrderBy, PageNumber, PageSize, Status);
        public GetCategoryDropdownQuery ToDropdownQuery() => new(Search, PageNumber);

        #endregion Public Methods
    }
}