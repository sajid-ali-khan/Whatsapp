using Whatsapp.Models;

namespace Whatsapp.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetContactsAsync(int userId);
    }
}
