using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Permission.GetOnePermission
{
    public class GetOnePermissionQuery : IRequest<Result<PermissionDto>>
    {
        #region Properties

        public GetOnePermissionQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        #endregion Properties
    }
}