using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Commands.Role.DeleteRole
{
    public class DeleteRoleCommandHandler(
        IRoleRepository _repository,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<DeleteRoleCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            if (result is not null)
            {
                _repository.Remove(result);
                await _unitOfWork.SaveChangesAsync();
                return Result.Success();
            }
            else
            {
                return Result.Failure(Error.Notfound("Role"));
            }
        }

        #endregion Public Methods
    }
}