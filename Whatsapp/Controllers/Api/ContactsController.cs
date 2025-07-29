using Microsoft.AspNetCore.Mvc;
using Whatsapp.Dtos;
using Whatsapp.Interfaces;
using Whatsapp.Models;

namespace Whatsapp.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactsRepository _contactsRepo;

        public ContactsController(IContactsRepository contactsRepo)
        {
            _contactsRepo = contactsRepo;
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContactByIdAsync(int contactId)
        {
            var contact = await _contactsRepo.GetContactAsync(contactId);
            if (contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactAsync([FromBody] ContactCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var realContact = new Contact()
            {
                User1Id = dto.User1Id,
                User2Id = dto.User2Id
            };
            var created = await _contactsRepo.AddContactAsync(realContact);
            if (created)
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpGet("users/with")]
        public async Task<IActionResult> GetContactByUsersAsync([FromQuery]int User1Id, [FromQuery]int User2Id)
        {
            var contact = await _contactsRepo.GetContactWithUsers(User1Id, User2Id);
            if (contact is null)
            {
                return NotFound();
            }

            return Ok(contact);

        }
    }
}
