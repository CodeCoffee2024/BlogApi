using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result>
    {
        #region Properties

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}