using Microsoft.EntityFrameworkCore;
using Whatsapp.Data;
using Whatsapp.Interfaces;
using Whatsapp.Models;

namespace Whatsapp.Repositories
{
    public class ContactsRepository: IContactsRepository
    {
        private readonly WhatsappDbContext _context;

        public ContactsRepository(WhatsappDbContext context)
        {
            _context = context;
        }
        public async Task<Contact?> GetContactAsync(int contactId)
        {
            return await _context.Contacts
                .Where(c => c.Id == contactId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AddContactAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Contact> GetContactWithUsers(int user1, int user2)
        {
            return await _context.Contacts
                .Where(c => (c.User1Id == user1 && c.User2Id == user2) || (c.User1Id == user2 && c.User2Id == user1))
                .FirstOrDefaultAsync();
        }
    }
}
