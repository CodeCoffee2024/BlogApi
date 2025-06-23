using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Commands.Permission.DeletePermission
{
    public class DeletePermissionCommandHandler(
        IPermissionRepository _repository,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<DeletePermissionCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
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
                return Result.Failure(Error.Notfound);
            }
        }

        #endregion Public Methods
    }
}