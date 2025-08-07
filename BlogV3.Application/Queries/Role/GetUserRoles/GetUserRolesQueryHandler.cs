using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Role.GetUserRoles
{
    public class GetUserRolesQueryHandler(IRoleRepository _repository, IMapper _mapper) : IRequestHandler<GetUserRolesQuery, Result<IEnumerable<UserRoleDto>>>
    {
        #region Public Methods

        public async Task<Result<IEnumerable<UserRoleDto>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetUserRolesAsync();
            var mappedResult = _mapper.Map<IEnumerable<UserRoleDto>>(result);
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}