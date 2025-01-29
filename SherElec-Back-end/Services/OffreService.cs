using AutoMapper;
using SherElec_Back_end.DTOs.Request;
using SherElec_Back_end.DTOs.Response;
using SherElec_Back_end.Models;
using SherElec_Back_end.Repositories.Interfaces;
using SherElec_Back_end.Services.Interfaces;

namespace SherElec_Back_end.Services
{
    public class OffreService : IOffreService
    {
        private readonly IOffreRepository _offreRepository;
        private readonly IMapper _mapper;

        public OffreService(IOffreRepository offreRepository, IMapper mapper)
        {
            _offreRepository = offreRepository;
            _mapper = mapper;
        }

        public async Task<OffreResponseDTO> CreateOfferAsync(OffreRequestDTO requestDto)
        {
            var offre = _mapper.Map<Offre>(requestDto);  // Mapper le DTO request en entité Offre
            await _offreRepository.CreateOffre(offre);
            return _mapper.Map<OffreResponseDTO>(offre);  // Mapper l'entité Offre en DTO response
        }

        public async Task<OffreResponseDTO> GetOfferByIdAsync(int id)
        {
            var offre = await _offreRepository.GetOfferById(id);
            if (offre == null)
                return null;
            return _mapper.Map<OffreResponseDTO>(offre);
        }
        public async Task<IEnumerable<OffreResponseDTO>> GetAllOffersAsync()
        {
            var offres = await _offreRepository.GetAllOffers();
            return _mapper.Map<IEnumerable<OffreResponseDTO>>(offres);
        }

        public async Task<OffreResponseDTO> UpdateOfferAsync(int id, OffreRequestDTO requestDto)
        {
            var offre = await _offreRepository.GetOfferById(id);
            if (offre == null)
            { return null; }

            _mapper.Map(requestDto, offre);
            await _offreRepository.UpdateOffer(offre);
            return _mapper.Map<OffreResponseDTO>(offre);
        }

        public async Task<bool> DeleteOfferAsync(int id)
        {
            var offre = await _offreRepository.GetOfferById(id);
            if (offre == null)
                return false;
            await _offreRepository.DeleteOffer(id);
            return true;
        }
    }
}
