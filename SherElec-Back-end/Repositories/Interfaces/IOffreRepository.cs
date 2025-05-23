﻿using SherElec_Back_end.Models;

namespace SherElec_Back_end.Repositories.Interfaces
{
    public interface IOffreRepository
    {
        Task CreateOffre(Offre offre);
        Task<Offre> GetOfferById(int id);

        Task<IEnumerable<Offre>> GetOffresByUserIdAsync(int userId);
        Task UpdateOffer(Offre offre);
        Task<IEnumerable<Offre>> GetAllOffers();

        Task DeleteOffer(int id);
    }
}
