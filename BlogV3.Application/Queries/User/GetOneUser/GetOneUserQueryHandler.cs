using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.User.GetOneUser
{
    public class GetOneUserQueryHandler(IUserRepository _repository, IMapper _mapper) : IRequestHandler<GetOneUserQuery, Result<UserDto>>
    {
        #region Public Methods

        public async Task<Result<UserDto>> Handle(GetOneUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return Result.Failure<UserDto>(Error.Notfound("User"));
            }
            var mappedResult = _mapper.Map<UserDto>(result);
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}