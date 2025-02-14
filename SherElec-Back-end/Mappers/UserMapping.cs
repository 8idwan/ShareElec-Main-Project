
using AutoMapper;
using global::SherElec_Back_end.DTOs.Request;
using global::SherElec_Back_end.DTOs.Response;
using global::SherElec_Back_end.Model;


namespace SherElec_Back_end.Mappers
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
