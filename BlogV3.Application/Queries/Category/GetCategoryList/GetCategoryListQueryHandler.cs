using System.Linq.Expressions;
using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Category.GetCategoryList
{
    public class GetCategoryListQueryHandler(
        ICategoryRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetCategoryListQuery, Result<PageResult<CategoryDto>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<CategoryDto>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Category, bool>>? statusFilter = null;
            statusFilter = c => c.Status == request.Status;
            var pagedResult = await _repository.GetPaginatedCategoriesAsync(
                request.PageNumber, request.PageSize, request.Search, request.OrderBy!, statusFilter);

            return Result.Success(
                new PageResult<CategoryDto>(
                    _mapper.Map<IReadOnlyList<CategoryDto>>(pagedResult.Items),
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
                );
        }

        #endregion Public Methods
    }
}