using AutoMapper;
using SherElec_Back_end.DTOs.Request;
using SherElec_Back_end.DTOs.Response;
using SherElec_Back_end.Models;

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