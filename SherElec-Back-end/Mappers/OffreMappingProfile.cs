using AutoMapper;
using SherElec_Back_end.DTOs.Request;
using SherElec_Back_end.DTOs.Response;
using SherElec_Back_end.Models;

namespace SherElec_Back_end.Mappers
{
    public class OffreMappingProfile : Profile
    {
        public OffreMappingProfile()
        {
            // Mapping pour convertir Offer en OfferResponseDto
            CreateMap<Offre, MesOffreResponseDTO>();

            // Mapping pour convertir Offre en OffreResponseDTO
            CreateMap<Offre, OffreResponseDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new UserResponseDTO
                {
                    IdUser = src.User.ID,
                    Nom = src.User.Nom,
                    Prenom = src.User.Prenom,
                    Email = src.User.Email,
                    NumeroTelephone = src.User.NumeroTelephone

                }));

            // Mapping pour convertir OfferRequestDto en Offer  
            CreateMap<OffreRequestDTO, Offre>();
        }
    }
}
