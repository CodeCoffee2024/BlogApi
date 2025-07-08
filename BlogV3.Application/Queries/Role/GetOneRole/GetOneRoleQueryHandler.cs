using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Role.GetOneRole
{
    public class GetOneRoleQueryHandler(IRoleRepository _repository, IMapper _mapper) : IRequestHandler<GetOneRoleQuery, Result<RoleDto>>
    {
        #region Public Methods

        public async Task<Result<RoleDto>> Handle(GetOneRoleQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return Result.Failure<RoleDto>(Error.Notfound("Role"));
            }
            var mappedResult = _mapper.Map<RoleDto>(result);
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}