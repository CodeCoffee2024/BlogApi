using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;

namespace BlogV3.Application.Queries.Role.GetRoleList
{
    public class GetRoleListQueryHandler(
        IRoleRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetRoleListQuery, Result<PageResult<GetRoleListResponse>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<GetRoleListResponse>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Role, bool>>? filter = c =>
            (string.IsNullOrEmpty(request.Status) || c.Status == request.Status);
            var pagedResult = await _repository.GetPaginatedRolesAsync(
                request.PageNumber, request.PageSize, request.Search, request.OrderBy!, filter);

            var mapped = _mapper.Map<IReadOnlyList<RoleDto>>(pagedResult.Items);
            var wrapped = new GetRoleListResponse(mapped);

            return Result.Success(
                new PageResult<GetRoleListResponse>(
                    new List<GetRoleListResponse> { wrapped },
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
            );
        }

        #endregion Public Methods
    }
}