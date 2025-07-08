using BlogV3.Api.Attributes;
using BlogV3.Api.Shared;
using BlogV3.Application.Commands.Module.DeleteModule;
using BlogV3.Application.Queries.Module.GetOneModule;
using BlogV3.Application.Requests;
using BlogV3.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModuleController : ApiBaseController
    {
        #region Public Constructors

        public ModuleController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("GetModules")]
        [PermissionAuthorize(Modules.MODULE, Permissions.VIEW)]
        public async Task<IActionResult> GetListing([FromQuery] ModuleRequest request, CancellationToken cancellationToken)
        {
            var query = request.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpDelete("{id}")]
        [PermissionAuthorize(Modules.MODULE, Permissions.MODIFY)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteModuleCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPost]
        [PermissionAuthorize(Modules.MODULE, Permissions.MODIFY)]
        public async Task<IActionResult> Create([FromBody] ModuleRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetAddCommand(UserId);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPut]
        [PermissionAuthorize(Modules.MODULE, Permissions.MODIFY)]
        public async Task<IActionResult> Update([FromBody] ModuleRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetUpdateCommand(UserId, request.Id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("{id}")]
        [PermissionAuthorize(Modules.MODULE, Permissions.VIEW)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new GetOneModuleQuery(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        #endregion Public Methods
    }
}