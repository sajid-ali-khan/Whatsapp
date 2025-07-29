using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Whatsapp.Data;
using Whatsapp.Interfaces;
using Whatsapp.Models;

namespace Whatsapp.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly WhatsappDbContext _context;

        public UserRepository(WhatsappDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserAsync(int userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<User>> GetContactsAsync(int userId)
        {
            var contactsList = await _context.Contacts
                .Where(c => c.User1Id == userId || c.User2Id == userId)
                .ToListAsync();

            var userContacts = contactsList.Select(c => c.User1Id == userId ? c.User2Id : c.User1Id);

            var contactsSet = new HashSet<int>(userContacts);
            var contacts = await _context.Users
                .Where(u => contactsSet.Contains(u.Id))
                .ToListAsync();

            return contacts;
        }

        public async Task<User?> GetUserByPhoneAsync(string phoneNumber)
        {
            return await _context.Users
                .Where(u => u.Phone == phoneNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
