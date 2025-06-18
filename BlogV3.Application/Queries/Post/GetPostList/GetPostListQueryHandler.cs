using System.Linq.Expressions;
using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Post.GetPostList
{
    public class GetPostListQueryHandler(
        IPostRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetPostListQuery, Result<PageResult<GetPostListResponse>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<GetPostListResponse>>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Post, bool>>? statusFilter = null;
            statusFilter = c => c.Status == request.Status;
            var pagedResult = await _repository.GetPaginatedPostsAsync(
                request.PageNumber, request.PageSize, request.Search, request.OrderBy!, statusFilter);

            var mapped = _mapper.Map<IReadOnlyList<PostDto>>(pagedResult.Items);
            var wrapped = new GetPostListResponse(mapped);

            return Result.Success(
                new PageResult<GetPostListResponse>(
                    new List<GetPostListResponse> { wrapped },
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
            );
        }

        #endregion Public Methods
    }
}