using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Permission.GetAllPermission
{
    public class GetAllPermissionQuery : IRequest<Result<IEnumerable<PermissionDto>>>
    {
    }
}