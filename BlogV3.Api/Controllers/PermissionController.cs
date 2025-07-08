using BlogV3.Api.Attributes;
using BlogV3.Api.Shared;
using BlogV3.Application.Commands.Permission.DeletePermission;
using BlogV3.Application.Queries.Permission.GetOnePermission;
using BlogV3.Application.Requests;
using BlogV3.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ApiBaseController
    {
        #region Public Constructors

        public PermissionController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("GetPermissions")]
        [PermissionAuthorize(Modules.PERMISSION, Permissions.VIEW)]
        public async Task<IActionResult> GetListing([FromQuery] PermissionRequest request, CancellationToken cancellationToken)
        {
            var query = request.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpDelete("{id}")]
        [PermissionAuthorize(Modules.PERMISSION, Permissions.MODIFY)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeletePermissionCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPost]
        [PermissionAuthorize(Modules.PERMISSION, Permissions.MODIFY)]
        public async Task<IActionResult> Create([FromBody] PermissionRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetAddCommand();
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPut("{id}")]
        [PermissionAuthorize(Modules.PERMISSION, Permissions.MODIFY)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PermissionRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetUpdateCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("{id}")]
        [PermissionAuthorize(Modules.PERMISSION, Permissions.VIEW)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new GetOnePermissionQuery(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        #endregion Public Methods
    }
}