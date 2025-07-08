using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Permission.GetOnePermission
{
    public class GetOnePermissionQueryHandler(IPermissionRepository _repository, IMapper _mapper) : IRequestHandler<GetOnePermissionQuery, Result<PermissionDto>>
    {
        #region Public Methods

        public async Task<Result<PermissionDto>> Handle(GetOnePermissionQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return Result.Failure<PermissionDto>(Error.Notfound("Permission"));
            }
            var mappedResult = _mapper.Map<PermissionDto>(result);
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}