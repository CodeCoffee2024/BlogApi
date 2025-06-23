using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Role.GetOneRole
{
    public class GetOneRoleQuery : IRequest<Result<RoleDto>>
    {
        #region Properties

        public GetOneRoleQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}