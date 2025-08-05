using BlogV3.Api.Attributes;
using BlogV3.Api.Shared;
using BlogV3.Application.Commands.User.DeleteUser;
using BlogV3.Application.Queries.Role.GetRoleStatuses;
using BlogV3.Application.Queries.User.GetOneUser;
using BlogV3.Application.Requests;
using BlogV3.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ApiBaseController
    {
        #region Public Constructors

        public UserController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("GetUsers")]
        [PermissionAuthorize(Modules.USER, Permissions.VIEW)]
        public async Task<IActionResult> GetListing([FromQuery] UserRequest request, CancellationToken cancellationToken)
        {
            var query = request.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("GetStatuses")]
        [PermissionAuthorize(Modules.USER, Permissions.VIEW)]
        public async Task<IActionResult> GetStatuses()
        {
            var result = await _sender.Send(new GetRoleStatusesQuery());
            return HandleResponse(result);
        }

        [HttpDelete("{id}")]
        [PermissionAuthorize(Modules.USER, Permissions.MODIFY)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPost]
        [PermissionAuthorize(Modules.USER, Permissions.MODIFY)]
        public async Task<IActionResult> Create([FromBody] UserRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetAddCommand(UserId);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPut("{id}")]
        [PermissionAuthorize(Modules.USER, Permissions.MODIFY)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetUpdateCommand(UserId, id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("{id}")]
        [PermissionAuthorize(Modules.USER, Permissions.VIEW)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new GetOneUserQuery(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        #endregion Public Methods
    }
}