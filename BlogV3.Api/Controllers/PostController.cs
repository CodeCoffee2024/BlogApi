using BlogV3.Api.Shared;
using BlogV3.Application.Queries.Post.GetOnePost;
using BlogV3.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
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
        public async Task<IActionResult> GetListing([FromQuery] PostRequest request, CancellationToken cancellationToken)
        {
            var query = request.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var command = new DeleteTagCommand(id);
        //    var result = await _sender.Send(command, cancellationToken);
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetAddCommand();
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new GetOnePostQuery(id);
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        #endregion Public Methods
    }
}