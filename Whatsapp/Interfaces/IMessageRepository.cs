using Whatsapp.Models;

namespace Whatsapp.Interfaces
{
    public interface IMessageRepository
    {
        Task<bool> SaveChanges();
        Task<bool> AddMessageAsync(Message message);
        Task<ICollection<Message>> GetMessagesAsync(int contactId);
        
    }
}
