using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.User.GetOneUser
{
    public class GetOneUserQuery : IRequest<Result<UserDto>>
    {
        #region Properties

        public GetOneUserQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}