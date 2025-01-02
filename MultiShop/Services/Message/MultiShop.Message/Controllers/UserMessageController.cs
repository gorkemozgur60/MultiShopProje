using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _userMessageService.GetAllMessageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByMessageId(int id)
        {
            var values = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj başarıyla kaydedildi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj başarıyla silindi.");
        }

        [HttpGet("GetMessageSendbox")]
        public async Task<IActionResult> GetMessageSendbox(string id)
        {
            var values = await _userMessageService.GetSendboxMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMessageInbox")]
        public async Task<IActionResult> GetMessageInbox(string id)
        {
            var values = await _userMessageService.GetInboxMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMessageCount")]
        public async Task<IActionResult> GetMessageCount()
        {
            var values = await _userMessageService.GetMessageCount();
            return Ok(values);
        }

        [HttpGet("GetTotalMessageCountByReceiverId/{id}")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
        {
            var values = await _userMessageService.GetTotalMessageCountByReceiverId(id);
            return Ok(values);
        }
    }
}
