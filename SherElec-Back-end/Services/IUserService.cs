using SherElec_Back_end.DTO;
using SherElec_Back_end.Model;

namespace SherElec_Back_end.Services
{
    public interface IUserService
    {
        public  Task ajoutCompteAsync(UserRequestDTO req);
    }
}
