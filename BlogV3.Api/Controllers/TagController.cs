using BlogV3.Api.Shared;
using BlogV3.Application.Commands.Tag.DeleteTag;
using BlogV3.Application.Queries.Tag.GetOneTag;
using BlogV3.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ApiBaseController
    {
        #region Public Constructors

        public TagController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("GetTags")]
        public async Task<IActionResult> GetListing([FromQuery] TagRequest request, CancellationToken cancellationToken)
        {
            var query = request.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteTagCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TagRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetAddCommand();
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new GetOneTagQuery(id);
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        #endregion Public Methods
    }
}