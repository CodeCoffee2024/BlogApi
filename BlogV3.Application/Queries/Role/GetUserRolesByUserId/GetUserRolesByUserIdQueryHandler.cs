using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Role.GetUserRolesByUserId
{
    public class GetUserRolesByUserIdQueryHandler(IRoleRepository _repository, IMapper _mapper) : IRequestHandler<GetUserRolesByUserIdQuery, Result<IEnumerable<UserRoleDto>>>
    {
        #region Public Methods

        public async Task<Result<IEnumerable<UserRoleDto>>> Handle(GetUserRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetUserRolesByUserIdAsync(request.Id);
            var mappedResult = _mapper.Map<IEnumerable<UserRoleDto>>(result);
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}