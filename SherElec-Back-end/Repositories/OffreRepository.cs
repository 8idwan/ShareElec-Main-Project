using Microsoft.EntityFrameworkCore;
using SherElec_Back_end.Data;
using SherElec_Back_end.Models;
using SherElec_Back_end.Repositories.Interfaces;

namespace SherElec_Back_end.Repositories
{
    public class OffreRepository : IOffreRepository
    {
        private readonly ApplicationDbContext _context;

        public OffreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOffre(Offre offre)
        {
            _context.Offers.Add(offre);
            await _context.SaveChangesAsync();
        }

        public async Task<Offre> GetOfferById(int id)
        {
            return await _context.Offers.FindAsync(id);
        }

        public async Task<IEnumerable<Offre>> GetAllOffers()
        {
            //return await _context.Offers.ToListAsync();
            return await _context.Offers
               .Include(o => o.User)  // Inclure l'utilisateur
               .ToListAsync();
        }


        public async Task UpdateOffer(Offre offer)
        {
            _context.Offers.Update(offer);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteOffer(int id)
        {
            var offer = await _context.Offers.FindAsync(id);
            if (offer != null)
            {
                _context.Offers.Remove(offer);
                await _context.SaveChangesAsync();
            }
        }


    }
}
