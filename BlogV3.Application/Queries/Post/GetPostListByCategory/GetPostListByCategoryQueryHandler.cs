using System.Linq.Expressions;
using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Post.GetPostListByCategory
{
    public class GetPostListByCategoryQueryHandler(
        IPostRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetPostListByCategoryQuery, Result<PageResult<GetPostListByCategoryResponse>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<GetPostListByCategoryResponse>>> Handle(GetPostListByCategoryQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Post, bool>>? statusFilter = null;
            statusFilter = c => c.Status == request.Status && c.Category!.Name == request.Category;
            var pagedResult = await _repository.GetPaginatedPostsAsync(
                request.PageNumber, request.PageSize, request.Search, request.OrderBy!, statusFilter);

            var mapped = _mapper.Map<IReadOnlyList<PostDto>>(pagedResult.Items);
            var wrapped = new GetPostListByCategoryResponse(mapped);

            return Result.Success(
                new PageResult<GetPostListByCategoryResponse>(
                    new List<GetPostListByCategoryResponse> { wrapped },
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
            );
        }

        #endregion Public Methods
    }
}