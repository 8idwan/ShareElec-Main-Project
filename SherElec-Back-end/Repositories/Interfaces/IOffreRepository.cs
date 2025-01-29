using SherElec_Back_end.Models;

namespace SherElec_Back_end.Repositories.Interfaces
{
    public interface IOffreRepository
    {
        Task CreateOffre(Offre offre);
        Task<Offre> GetOfferById(int id);
        Task UpdateOffer(Offre offre);
        Task<List<Offre>> GetAllOffers();

        Task DeleteOffer(int id);
    }
}
