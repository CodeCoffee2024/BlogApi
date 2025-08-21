using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Extensions;
using BlogV3.Common.Entities;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;

namespace BlogV3.Application.Queries.Post.GetPostListByCategory
{
    public class GetPostListByCategoryQueryHandler(
        IPostRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetPostListByCategoryQuery, Result<PageResult<PostDto>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<PostDto>>> Handle(GetPostListByCategoryQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Post, bool>>? statusFilter = null;
            statusFilter = c => c.Status == Status.Active.GetDescription() && c.Category!.Name == request.Category;

            var pagedResult = await _repository.GetPaginatedPostsAsync(
                request.PageNumber, request.PageSize, request.Search, request.OrderBy!, statusFilter);

            return Result.Success(
                new PageResult<PostDto>(
                    _mapper.Map<IReadOnlyList<PostDto>>(pagedResult.Items),
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
            );
        }

        #endregion Public Methods
    }
}