using Whatsapp.Models;

namespace Whatsapp.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(int userId);
        Task<ICollection<User>> GetContactsAsync(int userId);
        Task<User?> GetUserByPhoneAsync(string phoneNumber);
    }
}
