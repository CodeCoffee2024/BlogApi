using BlogV3.Api.Attributes;
using BlogV3.Api.Shared;
using BlogV3.Application.Commands.Role.DeleteRole;
using BlogV3.Application.Queries.Role.GetOneRole;
using BlogV3.Application.Queries.Role.GetRoleStatuses;
using BlogV3.Application.Queries.Role.GetUserRoles;
using BlogV3.Application.Queries.Role.GetUserRolesByUserId;
using BlogV3.Application.Requests;
using BlogV3.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ApiBaseController
    {
        #region Public Constructors

        public RoleController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("GetRoles")]
        [PermissionAuthorize(Modules.ROLE, Permissions.VIEW)]
        public async Task<IActionResult> GetListing([FromQuery] RoleRequest request, CancellationToken cancellationToken)
        {
            var query = request.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("GetUserRoles")]
        [PermissionAuthorize(Modules.ROLE, Permissions.VIEW)]
        public async Task<IActionResult> GetUserRoles(CancellationToken cancellationToken)
        {
            var command = new GetUserRolesQuery();
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("GetUserRolesByUserId/{id}")]
        [PermissionAuthorize(Modules.ROLE, Permissions.VIEW)]
        public async Task<IActionResult> GetUserRolesByUserId([FromRoute] string id, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(id, out var userId))
            {
                var command = new GetUserRolesByUserIdQuery(userId);
                var result = await _sender.Send(command, cancellationToken);
                return HandleResponse(result);
            }
            return HandleResponse(Domain.Abstractions.Result.Failure(Domain.Abstractions.Error.NullValue));
        }

        [HttpGet("GetStatuses")]
        [PermissionAuthorize(Modules.ROLE, Permissions.VIEW)]
        public async Task<IActionResult> GetStatuses()
        {
            var result = await _sender.Send(new GetRoleStatusesQuery());
            return HandleResponse(result);
        }

        [HttpDelete("{id}")]
        [PermissionAuthorize(Modules.ROLE, Permissions.MODIFY)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteRoleCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPost]
        [PermissionAuthorize(Modules.ROLE, Permissions.MODIFY)]
        public async Task<IActionResult> Create([FromBody] RoleRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetAddCommand(UserId);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPut("{id}")]
        [PermissionAuthorize(Modules.ROLE, Permissions.MODIFY)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RoleRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetUpdateCommand(id, UserId);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPut("UpdateUserRole/{userId}")]
        [PermissionAuthorize(Modules.ROLE, Permissions.MODIFY)]
        public async Task<IActionResult> UpdateUserRole([FromRoute] Guid userId, [FromBody] RoleRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetUpdateUserRoleCommand(userId);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("{id}")]
        [PermissionAuthorize(Modules.ROLE, Permissions.VIEW)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new GetOneRoleQuery(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        #endregion Public Methods
    }
}