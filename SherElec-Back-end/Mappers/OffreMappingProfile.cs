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
            CreateMap<Offre, OffreResponseDTO>();

            // Mapping pour convertir OfferRequestDto en Offer
            CreateMap<OffreRequestDTO, Offre>();
        }
    }
}
