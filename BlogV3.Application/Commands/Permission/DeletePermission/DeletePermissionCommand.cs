using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Permission.DeletePermission
{
    public class DeletePermissionCommand : IRequest<Result>
    {
        #region Properties

        public DeletePermissionCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}