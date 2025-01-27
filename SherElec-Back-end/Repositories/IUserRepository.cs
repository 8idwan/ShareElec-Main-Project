using SherElec_Back_end.Model;

namespace SherElec_Back_end.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
