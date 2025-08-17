using BlogV3.Api.Attributes;
using BlogV3.Api.Shared;
using BlogV3.Application.Commands.Post.DeletePost;
using BlogV3.Application.Queries.Post.GetOnePost;
using BlogV3.Application.Queries.Post.GetPostStatuses;
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
    public class PostController : ApiBaseController
    {
        #region Public Constructors

        public PostController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("GetPosts")]
        [PermissionAuthorize(Modules.POST, Permissions.VIEW)]
        public async Task<IActionResult> GetListing([FromQuery] PostRequest request, CancellationToken cancellationToken)
        {
            var query = request.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpDelete("{id}")]
        [PermissionAuthorize(Modules.POST, Permissions.MODIFY)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeletePostCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPost]
        [PermissionAuthorize(Modules.POST, Permissions.MODIFY)]
        public async Task<IActionResult> Create([FromForm] PostRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetAddCommand(UserId);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPut("{id}")]
        [PermissionAuthorize(Modules.POST, Permissions.MODIFY)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] PostRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetUpdateCommand(UserId, id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("GetStatuses")]
        [PermissionAuthorize(Modules.POST, Permissions.VIEW)]
        public async Task<IActionResult> GetStatuses()
        {
            var result = await _sender.Send(new GetPostStatusesQuery());
            return HandleResponse(result);
        }

        [HttpGet("{id}")]
        [PermissionAuthorize(Modules.POST, Permissions.VIEW)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new GetOnePostQuery(id);
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        #endregion Public Methods
    }
}