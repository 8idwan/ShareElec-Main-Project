using SherElec_Back_end.DTO;
using SherElec_Back_end.Model;
using SherElec_Back_end.Models;

namespace SherElec_Back_end.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUserById(int id);
         Task<User> GetUserByEmailAsync(string email);


        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task AddEmailVerification(EmailVerifier emailVerifier);

        Task<EmailVerifier> GetEmailVerification(string email, string code);


    }
}
