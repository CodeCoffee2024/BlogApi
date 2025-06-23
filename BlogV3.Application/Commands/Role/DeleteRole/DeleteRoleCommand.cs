using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Role.DeleteRole
{
    public class DeleteRoleCommand : IRequest<Result>
    {
        #region Properties

        public DeleteRoleCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}