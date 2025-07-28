using Microsoft.AspNetCore.Mvc;
using Whatsapp.Interfaces;
using Whatsapp.Models;

namespace Whatsapp.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userRepo.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{userId}/contacts")]
        public async Task<IActionResult> GetContacts(int userId)
        {
            var contacts = await _userRepo.GetContactsAsync(userId);
            return Ok(contacts);
        }

        [HttpGet("phone/{phoneNumber}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserByPhone(string phoneNumber)
        {
            var user = await _userRepo.GetUserByPhoneAsync(phoneNumber);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
}
