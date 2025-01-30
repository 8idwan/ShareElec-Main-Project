using SherElec_Back_end.DTOs.Request;
using SherElec_Back_end.DTOs.Response;
using SherElec_Back_end.Models;

namespace SherElec_Back_end.Services.Interfaces
{
    public interface IOffreService
    {
        Task<MesOffreResponseDTO> CreateOfferAsync(OffreRequestDTO requestDto);
        Task<MesOffreResponseDTO> GetOfferByIdAsync(int id);
        Task<IEnumerable<OffreResponseDTO>> GetAllOffersAsync();
        Task<MesOffreResponseDTO> UpdateOfferAsync(int id, OffreRequestDTO requestDto);
        Task<bool> DeleteOfferAsync(int id);
        Task<IEnumerable<MesOffreResponseDTO>> GetOffresByUserIdAsync(int userId);
    }
}
