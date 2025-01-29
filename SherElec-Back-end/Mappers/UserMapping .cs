using AutoMapper;
using SherElec_Back_end.DTO;
using SherElec_Back_end.Model;

namespace SherElec_Back_end.Mapper
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            // Configuration des mappings
            CreateMap<User, UserRespenseDTO>();
            CreateMap<UserRequestDTO, User>();
        }
    }
}
