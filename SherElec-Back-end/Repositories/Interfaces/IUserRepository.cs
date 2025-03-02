using global::SherElec_Back_end.Models;

namespace SherElec_Back_end.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUserById(int id);
         Task<User> GetUserByIdWithDeleted(int id);
        Task<User> GetUserByEmailAsync(string email);


        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task AddEmailVerification(EmailVerifier emailVerifier);

        Task<EmailVerifier> GetEmailVerification(string email, string code);


    }
}
