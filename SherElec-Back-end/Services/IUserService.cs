using SherElec_Back_end.DTO;
using SherElec_Back_end.Model;

namespace SherElec_Back_end.Services
{
    public interface IUserService
    {
        Task ajoutCompteAsync(UserRequestDTO req);
        string GenererToken(UserRespenseDTO utilisateur);
        Task<UserRespenseDTO> AuthentifierUtilisateurAsync(string email, string motDePasse);

        Task<UserRespenseDTO> UpdateUserAsync(int id, UserRequestDTO requestDto);
        Task removeUser(int id);
        Task<UserRespenseDTO> GetUserInfo(int id);
        Task InitiateEmailVerification(UserRequestDTO req);
        Task<bool> VerifyEmailAndCreateUser(string email, string code);

    }
}
