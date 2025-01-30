using SherElec_Back_end.DTOs.Request;
using SherElec_Back_end.DTOs.Response;

namespace SherElec_Back_end.Services.Interfaces
{
    public interface IOffreService
    {
        Task<OffreResponseDTO> CreateOfferAsync(OffreRequestDTO requestDto);
        Task<OffreResponseDTO> GetOfferByIdAsync(int id);
        Task<IEnumerable<OffreResponseDTO>> GetAllOffersAsync();
        Task<OffreResponseDTO> UpdateOfferAsync(int id, OffreRequestDTO requestDto);
        Task<bool> DeleteOfferAsync(int id);

        Task<IEnumerable<MesOffreResponseDTO>> GetOffresByUserIdAsync(int userId);

    }
}
