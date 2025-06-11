using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Tag.DeleteTag
{
    public class DeleteTagCommand : IRequest<Result>
    {
        #region Properties

        public DeleteTagCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}