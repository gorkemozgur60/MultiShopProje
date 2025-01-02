using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageStatisticController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageStatisticController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet("GetTotalMessageCountByReceiverId/{id}")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
        {
            var values = await _userMessageService.GetTotalMessageCountByReceiverId(id);
            return Ok(values);
        }
    }
}
