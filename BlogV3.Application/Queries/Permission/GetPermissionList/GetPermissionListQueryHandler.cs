using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Permission.GetPermissionList
{
    public class GetPermissionListQueryHandler(
        IPermissionRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetPermissionListQuery, Result<PageResult<GetPermissionListResponse>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<GetPermissionListResponse>>> Handle(GetPermissionListQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await _repository.GetPaginatedPostsAsync(
                request.PageNumber, request.PageSize, request.Search, request.OrderBy!);

            var mapped = _mapper.Map<IReadOnlyList<PermissionDto>>(pagedResult.Items);
            var wrapped = new GetPermissionListResponse(mapped);

            return Result.Success(
                new PageResult<GetPermissionListResponse>(
                    new List<GetPermissionListResponse> { wrapped },
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
            );
        }

        #endregion Public Methods
    }
}