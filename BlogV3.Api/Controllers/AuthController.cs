using BlogV3.Api.Shared;
using BlogV3.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ApiBaseController
    {
        #region Public Constructors

        public AuthController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("Login")]
        public async Task<IActionResult> GetListing([FromQuery] AuthRequest request, CancellationToken cancellationToken)
        {
            var query = request.LoginQuery();
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetRegisterCommand();
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        #endregion Public Methods
    }
}