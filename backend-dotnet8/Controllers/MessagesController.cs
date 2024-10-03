using backend_dotnet8.Core.Dtos.Message;
using backend_dotnet8.Core.Services.Interfaces;
using backend_dotnet8.DataLayer.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // Create a Message
        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> CreateNewMessage([FromBody] CreateMessageDto createMessageDto)
        {
            var result = await _messageService.CreateNewMessageAsync(User, createMessageDto);
            if (result.IsSucceed)
                return Ok(result.Message);

            return StatusCode(result.StatusCode, result.Message);
        }

        //get my message
        [HttpGet]
        [Route("mine")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetMessageDto>>> GetMyMessages() 
        {
            var messages = await _messageService.GetMyMessagesAsync(User);
            return Ok(messages);
        }
        
        //get all message from admin and owner
        [HttpGet]
        [Authorize(Roles =StaticUserRoles.OwnerAdmin)]
        public async Task<ActionResult<IEnumerable<GetMessageDto>>> GetMessages() 
        {
            var messages = await _messageService.GetMessagesAsync();
            return Ok(messages);
        }

    }
}
