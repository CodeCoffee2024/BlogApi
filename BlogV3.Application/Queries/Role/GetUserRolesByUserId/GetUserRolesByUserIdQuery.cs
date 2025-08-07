using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Role.GetUserRolesByUserId
{
    public class GetUserRolesByUserIdQuery : IRequest<Result<IEnumerable<UserRoleDto>>>
    {
        #region Public Constructors

        public GetUserRolesByUserIdQuery(Guid id)
        {
            Id = id;
        }

        #endregion Public Constructors

        #region Properties

        public Guid Id { get; set; }

        #endregion Properties
    }
}