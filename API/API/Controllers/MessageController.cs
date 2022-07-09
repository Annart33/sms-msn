using System.Threading.Tasks;
using API.DTO;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;

        public MessageController(IMapper mapper, IMessageService messageService)
        {
            _mapper = mapper;
            _messageService = messageService;
        }
        
        [HttpPost("save-message")]
        public async Task<IActionResult> SaveMessage(MessageRequest request)
        {
            var message = _mapper.Map<Message>(request);
            await _messageService.SaveMessage(message);
            return Ok();
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllMessages()
        {
            var messages = await _messageService.GetAllMessages();
            return Ok(messages);
        }
    }
}