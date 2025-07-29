using Whatsapp.Models;

namespace Whatsapp.Interfaces
{
    public interface IContactsRepository
    {
        Task<Contact?> GetContactAsync(int contactId);
        Task<bool> AddContactAsync(Contact contact);
        Task<bool> SaveChangesAsync();

        Task<Contact> GetContactWithUsers(int user1, int user2);
    }
}
