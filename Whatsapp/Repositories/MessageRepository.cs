using Microsoft.EntityFrameworkCore;
using Whatsapp.Data;
using Whatsapp.Interfaces;
using Whatsapp.Models;

namespace Whatsapp.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly WhatsappDbContext _context;

        public MessageRepository(WhatsappDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            return await SaveChanges();
        }

        public async Task<ICollection<Message>> GetMessagesAsync(int contactId)
        {
            var messages = await _context.Messages
                .Where(m => m.ContactId == contactId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();

            return messages;
        }
    }
}
