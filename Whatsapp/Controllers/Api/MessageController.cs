using Microsoft.AspNetCore.Mvc;
using Whatsapp.Dtos;
using Whatsapp.Interfaces;
using Whatsapp.Models;

namespace Whatsapp.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController: Controller
    {
        private readonly IMessageRepository _messageRepo;

        public MessageController(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }

        [HttpGet("contact/{contactId}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Message>))]
        public async Task<IActionResult> GetMessagesAsync(int contactId)
        {
            var messages = await _messageRepo.GetMessagesAsync(contactId);
            if (messages is null || !messages.Any())
            {
                return NotFound();
            }
            return Ok(messages);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddMessageAsync([FromBody] MessageCreateDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            var message = new Message
            {
                ContactId = dto.ContactId,
                SenderId = dto.SenderId,
                Content = dto.Content
            };

            var created = await _messageRepo.AddMessageAsync(message);

            if (created)
            {
                return StatusCode(201);
            }

            return StatusCode(500);
        }
    }
}
