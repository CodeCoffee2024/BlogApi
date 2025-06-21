using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Commands.Module.DeleteModule
{
    public class DeleteModuleCommand : IRequest<Result>
    {
        #region Properties

        public DeleteModuleCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}