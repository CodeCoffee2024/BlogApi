using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Module.GetOneModule
{
    public class GetOneModuleQuery : IRequest<Result<ModuleDto>>
    {
        #region Properties

        public GetOneModuleQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}