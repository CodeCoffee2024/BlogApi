using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Post.DeletePost
{
    public class DeletePostCommand : IRequest<Result>
    {
        #region Properties

        public DeletePostCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}