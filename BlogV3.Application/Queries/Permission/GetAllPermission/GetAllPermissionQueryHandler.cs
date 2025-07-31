using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Permission.GetAllPermission
{
    public class GetAllPermissionQueryHandler(IPermissionRepository _repository, IMapper _mapper) : IRequestHandler<GetAllPermissionQuery, Result<IEnumerable<PermissionDto>>>
    {
        #region Public Methods

        public async Task<Result<IEnumerable<PermissionDto>>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            if (result == null)
            {
                return Result.Failure<IEnumerable<PermissionDto>>(Error.Notfound("Permission"));
            }
            var mappedResult = _mapper.Map<IEnumerable<PermissionDto>>(result);
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}