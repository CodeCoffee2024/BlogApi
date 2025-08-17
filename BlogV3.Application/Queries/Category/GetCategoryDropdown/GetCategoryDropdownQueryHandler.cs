using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Category.GetCategoryDropdown
{
    public class GetCategoryDropdownQueryHandler(
        ICategoryRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetCategoryDropdownQuery, Result<PageResult<CategoryFragment>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<CategoryFragment>>> Handle(GetCategoryDropdownQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await _repository.GetPaginatedCategoriesAsync(
                request.PageNumber, request.PageNumber, request.Search, "name", null);

            return Result.Success(
                new PageResult<CategoryFragment>(
                    _mapper.Map<IReadOnlyList<CategoryFragment>>(pagedResult.Items),
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
                );
        }

        #endregion Public Methods
    }
}