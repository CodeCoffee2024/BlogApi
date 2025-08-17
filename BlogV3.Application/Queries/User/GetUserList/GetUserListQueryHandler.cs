using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;

namespace BlogV3.Application.Queries.User.GetUserList
{
    public class GetUserListQueryHandler(
        IUserRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetUserListQuery, Result<PageResult<UserDto>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<UserDto>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.User, bool>>? filter = c =>
            (string.IsNullOrEmpty(request.Status) || c.Status == request.Status) &&
            (request.Roles == null || !request.Roles.Any() || c.UserRoles.Any(ur => request.Roles.Select(r => r.Id).Contains(ur.RoleId)));

            var pagedResult = await _repository.GetPaginatedUsersAsync(
                request.PageNumber, request.PageSize, request.Search, request.OrderBy!, filter);

            return Result.Success(
                new PageResult<UserDto>(
                    _mapper.Map<IReadOnlyList<UserDto>>(pagedResult.Items),
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
            );
        }

        #endregion Public Methods
    }
}