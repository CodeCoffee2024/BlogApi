using BlogV3.Api.Shared;
using BlogV3.Application.Queries.ModuleGroup.GetModuleGroupList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemController : ApiBaseController
    {
        #region Public Methods

        public SystemController(ISender sender) : base(sender)
        {
        }

        [HttpGet("GetModuleGroups")]
        public async Task<IActionResult> GetAllGroups()
        {
            var result = await _sender.Send(new GetModuleGroupListQuery());
            return HandleResponse(result);
        }

        #endregion Public Methods
    }
}